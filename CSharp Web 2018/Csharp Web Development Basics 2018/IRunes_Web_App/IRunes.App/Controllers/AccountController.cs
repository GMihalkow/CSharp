namespace IRunes.App.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text.RegularExpressions;
    using IRunes.App.Views;
    using IRunes.Models;
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;
    using SIS.MvcFramework;
    using SIS.WebServer.Results;

    public class AccountController : BaseController
    {
        private const string InvalidRegisterInformationMessage = "<p style=\"text-align:center;\">Invalid password/username/email, please try again!</p>";

        private const string InvalidLoginInformationMessage = "<p style=\"text-align:center;\">Invalid username/password combination!<p>";

        private const string UsernameAlreadyExistsErrorMessage = "<p style=\"text-align:center;\">Username already exists!</p>";

        [HttpGetAttribute("/Users/Login")]
        public IHttpResponse GetLogin()
        {
            if (this.Request.Cookies.ContainsCookie(AuthenticationCookieKey))
            {
                string cookieValue = this.Request.Cookies.GetCookie(AuthenticationCookieKey).Value;
                string username = SIS.MvcFramework.Services.UserCookieService.DecryptString(cookieValue, SIS.MvcFramework.Services.UserCookieService.EncryptKey);

                Dictionary<string, string> loggedInReplaceParameters = new Dictionary<string, string>()
                {
                    {"{{{name}}}", username }
                };

                return this.View("Logged", HttpResponseStatusCode.Ok, loggedInReplaceParameters);
            }

            Dictionary<string, string> loginParameters = new Dictionary<string, string>()
            {
                {"{{{error}}}", string.Empty }
            };

            return this.View("Login", HttpResponseStatusCode.Ok, loginParameters);
        }

        [HttpPostAttribute("/Users/Login")]
        public IHttpResponse PostLogin()
        {
            string usernameOrEmail = WebUtility.UrlDecode(this.Request.FormData["username-or-email"].ToString().Trim());
            string password = SIS.MvcFramework.Services.HashService.Compute256Hash(this.Request.FormData["password"].ToString().Trim());

            string username =
                this.Context
                .Users
                .Where(user => user.Username == usernameOrEmail || user.Email == usernameOrEmail)
                .First()
                .Username;

            Dictionary<string, string> loginReplaceParameters = new Dictionary<string, string>()
            {
                {"{{{name}}}", username }
            };

            if (this.Context.Users.Any(user => (user.Username == usernameOrEmail || user.Email == usernameOrEmail) && user.Password == password))
            {
                HttpCookie cookie = new HttpCookie(AuthenticationCookieKey, SIS.MvcFramework.Services.UserCookieService.EncryptString(username, SIS.MvcFramework.Services.UserCookieService.EncryptKey));

                this.Request.Cookies.Add(cookie);
                this.Response.Cookies.Add(cookie);

                return this.View("Logged",  HttpResponseStatusCode.Ok, loginReplaceParameters);
            }
            else
            {
                Dictionary<string, string> backToLoginParameters = new Dictionary<string, string>()
                {
                    {"{{{error}}}", InvalidLoginInformationMessage }
                };

                return this.View("Login", HttpResponseStatusCode.BadRequest, backToLoginParameters);
            }
        }

        [HttpGetAttribute("/Users/Register")]
        public IHttpResponse GetRegister()
        {
            HttpCookie cookie;

            if (this.Request.Cookies.ContainsCookie(AuthenticationCookieKey))
            {
                this.Request.Cookies.GetCookie(AuthenticationCookieKey).Delete();

                cookie = this.Request.Cookies.GetCookie(AuthenticationCookieKey);

                this.Response.AddCookie(cookie);
            }

            Dictionary<string, string> registerErrorParameters = new Dictionary<string, string>()
            {
                {"{{{error}}}", string.Empty }
            };

            return this.View("Register",  HttpResponseStatusCode.Ok, registerErrorParameters);
        }

        [HttpPostAttribute("/Users/Register")]
        public IHttpResponse PostRegister()
        {
            Regex usernameAndPasswordRegex = new Regex(@"^\w+$");
            Regex emailRegex = new Regex(@"^[A-z]+\@[A-z]+\.[A-z]{1,4}$");

            string username = this.Request.FormData["username"].ToString();
            string rawPassword = this.Request.FormData["password"].ToString();

            string hashedPassword = SIS.MvcFramework.Services.HashService.Compute256Hash(rawPassword);
            string hashedConfirmPassword = SIS.MvcFramework.Services.HashService.Compute256Hash(rawPassword);

            string email = this.Request.FormData["email"].ToString();
            email = email.Replace("%40", "@");

            if (emailRegex.Match(email).Success == false ||
                usernameAndPasswordRegex.Match(rawPassword).Success == false ||
                rawPassword.Length < 3 ||
                rawPassword.Length > 50 ||
               (usernameAndPasswordRegex.Match(username).Success == false ||
               username.Length < 3 ||
               username.Length > 30))
            {

                Dictionary<string, string> registerErrorParameters = new Dictionary<string, string>()
                {
                    {"{{{error}}}", InvalidRegisterInformationMessage }
                };

                return this.View("Register", HttpResponseStatusCode.BadRequest, registerErrorParameters);
            }

            if (hashedConfirmPassword == hashedPassword)
            {
                //Adding user to db User user = new User()
                User user = new User
                {
                    Id = Guid.NewGuid().ToString(),
                    Username = username,
                    Password = hashedPassword,
                    Email = email
                };

                using (this.Context)
                {
                    if (this.Context.Users.Any(u => u.Username == username) == true)
                    {
                        Dictionary<string, string> registerErrorParameters = new Dictionary<string, string>()
                        {
                            { "{{{error}}}", UsernameAlreadyExistsErrorMessage}
                        };

                        return this.View("Register", HttpResponseStatusCode.BadRequest, registerErrorParameters);
                    }

                    this.Context.Users.Add(user);
                    this.Context.SaveChanges();
                }
            }

            //Adding cookie
            HttpCookie cookie = new HttpCookie(AuthenticationCookieKey, SIS.MvcFramework.Services.UserCookieService.EncryptString(username, SIS.MvcFramework.Services.UserCookieService.EncryptKey));

            this.Request.Cookies.Add(cookie);
            this.Response.Cookies.Add(cookie);

            Dictionary<string, string> loggedInParameters = new Dictionary<string, string>()
            {
                {"{{{name}}}", username }
            };

            return this.View("Logged",  HttpResponseStatusCode.Ok, loggedInParameters);
        }
    }
}