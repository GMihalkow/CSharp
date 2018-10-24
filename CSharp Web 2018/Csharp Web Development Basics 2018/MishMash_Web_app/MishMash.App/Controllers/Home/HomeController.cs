namespace MishMash.App.Controllers.Home
{
    using MishMash.App.Models;
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
                if(user.Role == Role.Admin)
                {
                    return this.View("Home/Index", user, "_AdminLayout");
                }
                else
                {
                    return this.View("Home/Index", user);
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