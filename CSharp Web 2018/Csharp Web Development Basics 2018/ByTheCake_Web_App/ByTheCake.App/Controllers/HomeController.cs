namespace ByTheCake.App.Controllers
{
    using System;
    using SIS.HTTP.Requests.Contracts;
    using SIS.Framework.Attributes.Methods;
    using SIS.Framework.ActionsResults.Base;
    using System.Collections.Generic;

    public class HomeController : BaseController
    {
        [HttpGet]
        public IActionResult Index(IHttpRequest request)
        {
            if (request.Cookies.ContainsCookie(AuthenticationCookieKey)
                && request.Cookies.GetCookie(AuthenticationCookieKey).Expires >= DateTime.UtcNow)
            {
                string cookieData = request.Cookies.GetCookie(AuthenticationCookieKey).Value;

                string username = this.cookieService.GetUserData(cookieData, EncryptKey);

                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    {"@Name", username }
                };

                return this.View("logged", parameters);
            }

            return this.View("index");
        }
    }
}