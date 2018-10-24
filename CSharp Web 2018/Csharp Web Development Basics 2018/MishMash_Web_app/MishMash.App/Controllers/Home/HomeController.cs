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

                    SuggestedChannels =
                            this.DbContext
                            .Channels
                            .Include(ch => ch.Tags)
                            .Include(ch => ch.Followers)
                            .Where(ch => ch.Tags.Any(t => t.Tag.Name == "common"))
                            .ToArray(),

                    SeeOtherChannels =
                            this.DbContext
                            .Channels
                            .Include(ch => ch.Tags)
                            .Include(ch => ch.Followers)
                            .Where(ch => ch
                                .Tags
                                .Any(t => t.Tag.Name == "common") == false
                                &&
                                ch.Followers.Any(u => u.UserId == user.Id) == false)
                            .ToArray()
                };

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