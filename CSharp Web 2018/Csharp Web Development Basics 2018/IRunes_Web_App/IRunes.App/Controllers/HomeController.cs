namespace IRunes.App.Controllers
{
    using SIS.HTTP.Enums;
    using SIS.HTTP.Responses.Contracts;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Contracts.Services;
    using System.Collections.Generic;

    public class HomeController : BaseController
    {
        [HttpGetAttribute("/")]
        public IHttpResponse Index()
        {
            if (this.Request.Cookies.ContainsCookie(AuthenticationCookieKey))
            {
                string cookieValue = this.Request.Cookies.GetCookie(AuthenticationCookieKey).Value;

                string username =
                    this.UserCookieService
                    .DecryptString(cookieValue, EncryptKey);

                Dictionary<string, string> loggedInParameters = new Dictionary<string, string>()
                    {
                        {"{{{name}}}", username}
                    };

                return this.View("Logged", HttpResponseStatusCode.Ok, loggedInParameters);
            }
            else
            {
                return this.View("Index", HttpResponseStatusCode.Ok, null);
            }
        }
    }
}