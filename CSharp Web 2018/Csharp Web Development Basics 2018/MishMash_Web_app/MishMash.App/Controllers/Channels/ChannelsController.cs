namespace MishMash.App.Controllers.Channels
{
    using Microsoft.EntityFrameworkCore;
    using MishMash.App.Models;
    using MishMash.App.ViewModels.Channels;
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
                    Name = tag,
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

            User user = this.DbContext.Users.First(u => u.Username == this.User);

            UserChannel userChannel = new UserChannel()
            {
                UserId = user.Id,
                ChannelId = channel.Id
            };

            this.DbContext.Add(userChannel);
            this.DbContext.SaveChanges();

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
    }
}