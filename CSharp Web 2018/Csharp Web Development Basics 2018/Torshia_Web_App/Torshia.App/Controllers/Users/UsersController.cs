namespace Torshia.App.Controllers.Users
{
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Torshia.App.Models;
    using Torshia.App.Models.Enums;
    using Torshia.App.ViewModels.Users;

    public class UsersController : BaseController
    {
        [HttpGet("/Users/Register")]
        public IHttpResponse Register()
        {
            return this.View("Users/Register", "_GuestLayout");
        }

        [HttpPost("/Users/Register")]
        public IHttpResponse Register(PostRegisterViewModel model)
        {
            Regex usernameAndPasswordRegex = new Regex(@"^\w+$");
            Regex emailRegex = new Regex(@"^[A-z]+\@[A-z]+\.[A-z]{1,4}$");

            string hashedPassword = this.hashService.Hash(model.Password);
            string hashedConfirmPassword = this.hashService.Hash(model.Password);

            model.Email = StringExtensions.UrlDecode(model.Email);

            if (emailRegex.Match(model.Email).Success == false ||
                usernameAndPasswordRegex.Match(model.Password).Success == false ||
                model.Password.Length < 3 ||
                model.Password.Length > 50 ||
               (usernameAndPasswordRegex.Match(model.Username).Success == false ||
               model.Username.Length < 3 ||
               model.Username.Length > 30))
            {

                return this.BadRequestError("Invalid username or password format!");
            }
            if (this.DbContext.Users.Any(user => user.Email == model.Email))
            {
                return this.BadRequestError("Email is already in use!");
            }
            if (hashedConfirmPassword == hashedPassword)
            {
                //Adding user to db 

                User user = new User()
                {
                    Username = model.Username,
                    Password = hashedPassword,
                    Email = model.Email
                };

                if (!this.DbContext.Users.Any())
                {
                    user.Role = Role.Admin;
                    model.Role = Role.Admin;
                }
                else
                {
                    user.Role = Role.User;
                    model.Role = Role.User;
                }

                using (this.DbContext)
                {
                    if (this.DbContext.Users.Any(u => u.Username == model.Username) == true)
                    {
                        return this.BadRequestError("Username already exists!");
                    }

                    this.DbContext.Users.Add(user);
                    this.DbContext.SaveChanges();
                }

            }
            //Adding cookie
            HttpCookie cookie = new HttpCookie(AuthenticationCookieKey, this.UserCookieService.EncryptString(model.Username));

            this.Request.Cookies.Add(cookie);
            this.Response.Cookies.Add(cookie);
            if (model.Role == Role.Admin)
            {
                return this.Redirect("/");

            }
            else
            {
                return this.Redirect("/");

            }
        }

        [HttpGet("/Users/Login")]
        public IHttpResponse Login()
        {
            return this.View("Users/Login");
        }

        [HttpPost("/Users/Login")]
        public IHttpResponse Login(PostRegisterViewModel model)
        {
            string hashedPassword = this.hashService.Hash(model.Password);

            if (!(this.DbContext.Users.Any(user =>
                (user.Username == model.Username.Trim())
            && user.Password == hashedPassword)))
            {
                return this.BadRequestError("Invalid user information!");
            }
            else
            {
                model.Role = this.DbContext.Users.First(u => u.Username == model.Username.Trim()).Role;

                HttpCookie cookie = new HttpCookie(AuthenticationCookieKey, this.UserCookieService.EncryptString(model.Username));

                this.Request.Cookies.Add(cookie);
                this.Response.Cookies.Add(cookie);
            }

            return this.Redirect("/");
        }

        [HttpGet("/Users/Logout")]
        public IHttpResponse Logout()
        {
            if (this.Request.Cookies.ContainsCookie(AuthenticationCookieKey))
            {
                var cookie = this.Request.Cookies.GetCookie(AuthenticationCookieKey);
                cookie.Delete();
                this.Response.AddCookie(cookie);
                return this.Redirect("/");
            }
            else
            {
                return this.Redirect("/Users/Login");
            }
        }
    }
}