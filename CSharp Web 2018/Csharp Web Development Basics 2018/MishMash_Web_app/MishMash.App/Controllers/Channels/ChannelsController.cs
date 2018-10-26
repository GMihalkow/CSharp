namespace MishMash.App.Controllers.Channels
{
    using Microsoft.EntityFrameworkCore;
    using MishMash.App.Models;
    using MishMash.App.ViewModels.Channels;
    using MishMash.App.ViewModels.Users;
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class ChannelsController : BaseController
    {
        [HttpGet("/Channels/Create")]
        public IHttpResponse Create()
        {
            Role userRole = this.DbContext.Users.Where(u => u.Username == this.User).First().Role;

            if (userRole != Role.Admin)
            {
                return BadRequestError("Page not found 404");
            }
            return this.View("Channels/Create", "_AdminLayout");
        }

        [HttpPost("/Channels/Create")]
        public IHttpResponse Create(PostChannelViewModel model)
        {
            Regex channelNameRegex = new Regex(@"^\w+$");

            if ((!channelNameRegex.Match(model.Name).Success) || model.Name.Length < 3 ||
               model.Name.Length > 30)
            {
                return this.BadRequestError("Invalid channel name format!");
            }
            if (this.DbContext.Channels.Any(ch => ch.Name == model.Name))
            {
                return this.BadRequestError("Channel already exists!");
            }

            Channel channel = new Channel()
            {
                Name = model.Name,
                Description = model.Description,
                Type = (ChannelType)Enum.Parse(typeof(ChannelType), model.ChannelType),
                Followers = new List<UserChannel>()
            };

            this.DbContext.Channels.Add(channel);
            this.DbContext.SaveChanges();

            foreach (var tag in model.Tags.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries))
            {
                int index = 0;
                index++;
                Tag newTag = new Tag()
                {
                    Name = tag.Trim(),
                };

                if (this.DbContext.Tags.Any(t => t.Name == newTag.Name))
                {

                }
                else
                {
                    this.DbContext.Tags.Add(newTag);
                    this.DbContext.SaveChanges();
                }

                ChannelTag channelTag = new ChannelTag()
                {
                    ChannelId = channel.Id,
                    TagId = this.DbContext.Tags.First(t => t.Name == newTag.Name).Id
                };
                this.DbContext.ChannelTags.Add(channelTag);

                this.DbContext.SaveChanges();
            }

            return this.Redirect($"/Channels/Details?Id={channel.Id}");
        }

        [HttpGet("/Channels/Details")]
        public IHttpResponse Details(int Id)
        {
            if (!this.DbContext.Channels.Any(ch => ch.Id == Id))
            {
                return this.BadRequestError("Channel not found!");
            }

            Channel channel =
                this.DbContext
                .Channels
                .Where(ch => ch.Id == Id)
                .Include(ch => ch.Followers)
                .Include(ch => ch.Tags)
                .ThenInclude(ch => ch.Tag)
                .First();

            Role userRole = this.DbContext.Users.Where(u => u.Username == this.User).First().Role;

            if (userRole != Role.Admin)
            {
                return this.View("Channels/Details", channel);
            }
            else
            {
                return this.View("Channels/Details", channel, "_AdminLayout");
            }



        }

        [HttpGet("/Channels/Followed")]
        public IHttpResponse Followed()
        {
            User user = null;

            if (this.Request.Cookies.ContainsCookie("-auth.mish"))
            {
                string cookieValue = this.Request.Cookies.GetCookie("-auth.mish").Value;
                string username = this.UserCookieService.DecryptString(cookieValue);

                user = this.DbContext.Users.First(u => u.Username == username);
            }

            UserWithChannelsViewModel userModel = new UserWithChannelsViewModel()
            {
                Role = user.Role,

                FollowedChannels =
                               this.DbContext
                               .UserChannels
                               .Where(uc => uc.UserId == user.Id)
                               .Include(uc => uc.Channel.Type)
                               .Include(uc => uc.Channel)
                               .Select(uc => uc.Channel)
                               .Include(uc => uc.Followers)
                               .ToArray(),

            };

            if (user.Role == Role.Admin)
            {
                return this.View("Channels/Followed", userModel, "_AdminLayout");
            }
            else
            {
                return this.View("Channels/Followed", userModel);
            }
        }

        [HttpGet("/Channels/Unfollow")]
        public IHttpResponse Unfollow(int Id)
        {
            if (!this.DbContext.Channels.Any(ch => ch.Id == Id))
                return this.BadRequestError("Channel doesn't exist!");

            var userChannel = this.DbContext.UserChannels.Where(w => w.ChannelId == Id && w.User.Username == this.User).First();
            this.DbContext.UserChannels.Remove(userChannel);
            this.DbContext.SaveChanges();

            return this.Redirect("/Channels/Followed");
        }

        [HttpGet("/Channels/Follow")]
        public IHttpResponse Follow(int Id)
        {
            if (!this.DbContext.Channels.Any(ch => ch.Id == Id))
                return this.BadRequestError("Channel doesn't exist!");

            int userId = this.DbContext.Users.Where(u => u.Username == this.User).First().Id;
            UserChannel userChannel = new UserChannel()
            {
                UserId = userId,
                ChannelId = Id
            };
            if (this.DbContext.UserChannels.Any(uc => uc.UserId == userId && uc.ChannelId == Id))
            {
                return this.BadRequestError("You have already followed this channel!");
            }
            this.DbContext.UserChannels.Add(userChannel);
            this.DbContext.SaveChanges();

            return this.Redirect("/");
        }
    }
}