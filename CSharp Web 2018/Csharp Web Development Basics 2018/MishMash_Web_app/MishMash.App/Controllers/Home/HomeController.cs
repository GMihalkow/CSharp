namespace MishMash.App.Controllers.Home
{
    using Microsoft.EntityFrameworkCore;
    using MishMash.App.Models;
    using MishMash.App.ViewModels.Users;
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;
    using System.Linq;

    public class HomeController : BaseController
    {
        [HttpGet("/Home/Index")]
        public IHttpResponse Index()
        {
            User user = null;

            if (this.Request.Cookies.ContainsCookie("-auth.mish"))
            {
                string cookieValue = this.Request.Cookies.GetCookie("-auth.mish").Value;
                string username = this.UserCookieService.DecryptString(cookieValue);

                user = this.DbContext.Users.First(u => u.Username == username);
            }

            if (user != null)
            {
                UserWithChannelsViewModel userModel = new UserWithChannelsViewModel()
                {
                    Role = user.Role,

                    FollowedChannels =
                                this.DbContext
                                .UserChannels
                                .Where(uc => uc.UserId == user.Id)
                                .Include(uc => uc.Channel)
                                .Select(uc => uc.Channel)
                                .Include(uc => uc.Followers)
                                .ToArray(),

                    CommonTags =
                            this.DbContext
                            .ChannelTags
                            .GroupBy(p => p.TagId)
                            .Select(p => p.Select(w => w.Tag))
                            .Where(t => t.Count() > 1)
                            .SelectMany(x => x.Select(q => q.Name))
                            .Distinct()
                            .ToArray(),
                };

                userModel.SuggestedChannels =
                            this.DbContext
                            .Channels
                            .Include(ch => ch.Tags)
                            .Include(ch => ch.Followers)
                            .Where(p => p.Tags
                                        .Any(t => userModel
                                            .CommonTags.Contains(t.Tag.Name))
                                            &&
                                  p.Followers.Any(u => u.UserId == user.Id) == false)
                            .ToArray();

                userModel.SeeOtherChannels =
                           this.DbContext
                           .Channels
                           .Include(ch => ch.Tags)
                           .Include(ch => ch.Followers)
                           .Where(p => p.Tags
                                        .Any(t => userModel
                                            .CommonTags.Contains(t.Tag.Name)) == false
                                            &&
                                  p.Followers.Any(u => u.UserId == user.Id) == false)
                           .ToArray();


                if (user.Role == Role.Admin)
                {
                    return this.View("Home/Index", userModel, "_AdminLayout");
                }
                else
                {
                    return this.View("Home/Index", userModel);
                }
            }
            else
            {
                return this.View("Home/LoggedOutIndex");
            }
        }

        [HttpGet("/")]
        public IHttpResponse RootIndex()
        {
            return this.Redirect("/Home/Index");
        }
    }
}