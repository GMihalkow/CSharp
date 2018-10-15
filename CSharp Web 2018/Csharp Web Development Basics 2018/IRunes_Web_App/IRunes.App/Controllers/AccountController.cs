namespace IRunes.App.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text.RegularExpressions;
    using IRunes.App.ViewModels.Account;
    using IRunes.Models;
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Responses.Contracts;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Extenstions;
    using SIS.MvcFramework.Services.Contracts;

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
        public IHttpResponse PostLogin(DoLoginInputModel model)
        {
            model.Password = this.hashService.Compute256Hash(model.Password);

            if (!(this.Context.Users.Any(user =>
                (user.Username == model.UsernameOrEmail.Trim() || user.Email == model.UsernameOrEmail.Trim())
            && user.Password == model.Password)))
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
                    .Where(user => user.Username == model.UsernameOrEmail.Trim() || user.Email == model.UsernameOrEmail.Trim())
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
        public IHttpResponse PostRegister(DoRegisterInputModel model)
        {
            Regex usernameAndPasswordRegex = new Regex(@"^\w+$");
            Regex emailRegex = new Regex(@"^[A-z]+\@[A-z]+\.[A-z]{1,4}$");


            string hashedPassword = this.hashService.Compute256Hash(model.Password);
            string hashedConfirmPassword = this.hashService.Compute256Hash(model.Password);

            model.Email = StringExtensions.UrlDecode(model.Email);

            if (emailRegex.Match(model.Email).Success == false ||
                usernameAndPasswordRegex.Match(model.Password).Success == false ||
                model.Password.Length < 3 ||
                model.Password.Length > 50 ||
               (usernameAndPasswordRegex.Match(model.Username).Success == false ||
               model.Username.Length < 3 ||
               model.Username.Length > 30))
            {
                Dictionary<string, string> registerErrorParameters = new Dictionary<string, string>()
                {
                    {"{{{error}}}", InvalidRegisterInformationMessage }
                };

                return this.View("Register", HttpResponseStatusCode.BadRequest, registerErrorParameters);
            }
            if (this.Context.Users.Any(user => user.Email == model.Email))
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
                    Username = model.Username,
                    Password = hashedPassword,
                    Email = model.Email
                };

                using (this.Context)
                {
                    if (this.Context.Users.Any(u => u.Username == model.Username) == true)
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
            HttpCookie cookie = new HttpCookie(AuthenticationCookieKey, this.UserCookieService.EncryptString(model.Username, EncryptKey));

            this.Request.Cookies.Add(cookie);
            this.Response.Cookies.Add(cookie);

            Dictionary<string, string> loggedInParameters = new Dictionary<string, string>()
            {
                {"{{{name}}}", model.Username }
            };

            return this.View("Logged", HttpResponseStatusCode.Ok, loggedInParameters);
        }
    }
}