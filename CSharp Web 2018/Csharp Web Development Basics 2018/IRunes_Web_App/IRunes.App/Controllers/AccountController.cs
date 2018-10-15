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
    using SIS.MvcFramework.Services.Contracts;
    using SIS.WebServer.Results;

    public class AccountController : BaseController
    {
        private const string InvalidRegisterInformationMessage
            = "<center><div class=\"alert alert-danger\" role=\"alert\">Invalid password/username/email, please try again!</div></center>";

        private const string InvalidLoginInformationMessage
            = "<center><div class=\"alert alert-danger\" role=\"alert\">Invalid username/password combination!<div></center>";

        private const string UsernameAlreadyExistsErrorMessage
            = "<center><div class=\"alert alert-danger\" role=\"alert\">Username already exists!</div></center>";

        private const string EmailAlreadyExistsErrorMessage
            = "<center><div class=\"alert alert-danger\" role=\"alert\">Email is already taken!</div></center>";

        private readonly IHashService hashService;

        public AccountController(IHashService hashService)
        {
            this.hashService = hashService;
        }

        [HttpGetAttribute("/Users/Login")]
        public IHttpResponse GetLogin()
        {
            if (this.Request.Cookies.ContainsCookie(AuthenticationCookieKey))
            {
                string cookieValue = this.Request.Cookies.GetCookie(AuthenticationCookieKey).Value;
                string username = this.UserCookieService.DecryptString(cookieValue, EncryptKey);

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
            string password = this.hashService.Compute256Hash(this.Request.FormData["password"].ToString().Trim());

            if (!(this.Context.Users.Any(user => (user.Username == usernameOrEmail || user.Email == usernameOrEmail) && user.Password == password)))
            {
                Dictionary<string, string> backToLoginParameters = new Dictionary<string, string>()
                {
                    {"{{{error}}}", InvalidLoginInformationMessage }
                };

                return this.View("Login", HttpResponseStatusCode.BadRequest, backToLoginParameters);
            }
            else
            {
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

                HttpCookie cookie = new HttpCookie(AuthenticationCookieKey, this.UserCookieService.EncryptString(username, EncryptKey));

                this.Request.Cookies.Add(cookie);
                this.Response.Cookies.Add(cookie);

                return this.View("Logged", HttpResponseStatusCode.Ok, loginReplaceParameters);

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

            return this.View("Register", HttpResponseStatusCode.Ok, registerErrorParameters);
        }

        [HttpPostAttribute("/Users/Register")]
        public IHttpResponse PostRegister()
        {
            Regex usernameAndPasswordRegex = new Regex(@"^\w+$");
            Regex emailRegex = new Regex(@"^[A-z]+\@[A-z]+\.[A-z]{1,4}$");

            string username = this.Request.FormData["username"].ToString();
            string rawPassword = this.Request.FormData["password"].ToString();

            string hashedPassword = this.hashService.Compute256Hash(rawPassword);
            string hashedConfirmPassword = this.hashService.Compute256Hash(rawPassword);

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
            if (this.Context.Users.Any(user => user.Email == email))
            {
                Dictionary<string, string> registerErrorParameters = new Dictionary<string, string>()
                {
                    {"{{{error}}}", EmailAlreadyExistsErrorMessage }
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
            HttpCookie cookie = new HttpCookie(AuthenticationCookieKey, this.UserCookieService.EncryptString(username, EncryptKey));

            this.Request.Cookies.Add(cookie);
            this.Response.Cookies.Add(cookie);

            Dictionary<string, string> loggedInParameters = new Dictionary<string, string>()
            {
                {"{{{name}}}", username }
            };

            return this.View("Logged", HttpResponseStatusCode.Ok, loggedInParameters);
        }
    }
}