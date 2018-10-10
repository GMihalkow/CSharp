namespace IRunes.App.Controllers
{
    using IRunes.App.Views;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;
    using SIS.MvcFramework;
    using SIS.WebServer.Results;
    using SIS.WebServer.Routing;
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
                    SIS.MvcFramework.Services.UserCookieService
                    .DecryptString(cookieValue, SIS.MvcFramework.Services.UserCookieService.EncryptKey);

                Dictionary<string, string> loggedInParameters = new Dictionary<string, string>()
                    {
                        {"{{{name}}}", username}
                    };

                return this.View("Logged",  HttpResponseStatusCode.Ok, loggedInParameters);
            }
            else
            {
                return this.View("Index",  HttpResponseStatusCode.Ok, null);
            }
        }
    }
}