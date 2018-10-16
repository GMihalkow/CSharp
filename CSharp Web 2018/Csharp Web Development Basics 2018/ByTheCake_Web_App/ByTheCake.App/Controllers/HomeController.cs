namespace ByTheCake.App.Controllers
{
    using System;
    using ByTheCake.Data;
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;
    using ByTheCake.Models;
    using SIS.WebServer.Results;
    using SIS.Framework.Attributes.Methods;
    using SIS.Framework.ActionsResults.Contracts;
    using SIS.Framework.ActionsResults.Base;
    using System.Collections.Generic;

    public class HomeController : BaseController
    {
        [HttpGet]
        public IActionResult Index(IHttpRequest request)
        {
            if (request.Cookies.ContainsCookie("-auth"))
            {
                string cookieData = request.Cookies.GetCookie("-auth").Value;

                string username = this.cookieService.GetUserData(cookieData, EncryptKey);

                Dictionary<string, string> parameters = new Dictionary<string, string>()
                {
                    {"@Name", username }
                };

                return this.View("logged", parameters);
            }

            return this.View("index");
        }

        //[HttpPostAttribute]
        //public IHttpResponse PostIndex()
        //{
        //    HashService hashService = new HashService();

        //    string username = this.Request.FormData["username"].ToString().Trim();

        //    string password = hashService.Compute256Hash(this.Request.FormData["password"].ToString().Trim());

        //    string confirmPassword = hashService.Compute256Hash(this.Request.FormData["confirm-password"].ToString().Trim());

        //    if (password != confirmPassword)
        //    {
        //        return new HtmlResult(new RegisterView().View() + "<p>Password don't match!</p>", HttpResponseStatusCode.Ok);
        //    }

        //    ByTheCakeDbContext context = new ByTheCakeDbContext();
        //    EncryptService encryptService = new EncryptService();

        //    using (context)
        //    {
        //        User user = new User()
        //        {
        //            Username = username,
        //            Password = password,
        //            ConfirmPassword = confirmPassword
        //        };

        //        context.Users.Add(user);
        //        context.SaveChanges();
        //    }
        //    var response = new RedirectResult("/");
        //    this.Response.Cookies.Add(new HttpCookie("-auth", encryptService.Encrypt(username, "123")));
        //    this.Request.Cookies.Add(new HttpCookie("-auth", encryptService.Encrypt(username, "123")));
        //    ;
        //    return response;
        //}
    }
}