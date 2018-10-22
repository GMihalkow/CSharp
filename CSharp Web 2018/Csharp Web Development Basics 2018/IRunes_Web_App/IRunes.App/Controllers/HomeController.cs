namespace IRunes.App.Controllers
{
    using IRunes.App.ViewModels.Account;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Responses.Contracts;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Contracts.Services;
    using System;
    using System.Collections.Generic;

    public class HomeController : BaseController
    {
        [HttpGetAttribute("/")]
        public IHttpResponse Index()
        {
            if (this.Request.Cookies.ContainsCookie(AuthenticationCookieKey)
                && this.Request.Cookies.GetCookie(AuthenticationCookieKey).Expires >= DateTime.UtcNow)
            {
                string cookieValue = this.Request.Cookies.GetCookie(AuthenticationCookieKey).Value;

                string username =
                    this.UserCookieService
                    .DecryptString(cookieValue, EncryptKey);

                DoLoginViewModel user = new DoLoginViewModel()
                {
                    UsernameOrEmail = username
                };

                return this.View("Logged", HttpResponseStatusCode.Ok, user);
            }
            else
            {
                return this.View<string>("index", HttpResponseStatusCode.Ok);
            }
        }
    }
}