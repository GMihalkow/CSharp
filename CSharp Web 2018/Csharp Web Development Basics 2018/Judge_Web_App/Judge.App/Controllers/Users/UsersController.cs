namespace Judge.App.Controllers.Users
{
    using Judge.App.Models;
    using Judge.App.Models.Enums;
    using Judge.App.ViewModels.Users;
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class UsersController : BaseController
    {
        public IHttpResponse Login()
        {
            return this.View();
        }

        public IHttpResponse Register()
        {
            return this.View();
        }

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

        [HttpPost]
        public IHttpResponse Register(PostRegisterViewModel model)
        {
            if (model.Conditions == null)
                return this.BadRequestErrorWithView("You must agree with the terms of conditions before registrating!");

            Regex usernameAndPasswordRegex = new Regex(@"^\w+$");
            Regex emailRegex = new Regex(@"^[A-z]+\@[A-z]+\.[A-z]{1,4}$");

            string hashedPassword = this.hashService.Hash(model.Password);
            string hashedConfirmPassword = this.hashService.Hash(model.ConfirmPassword);

            model.Email = StringExtensions.UrlDecode(model.Email);

            if (emailRegex.Match(model.Email).Success == false ||
                usernameAndPasswordRegex.Match(model.Password).Success == false ||
                model.Password.Length < 3 ||
                model.Password.Length > 50 ||
                model.FullName.Length < 3 ||
               (usernameAndPasswordRegex.Match(model.FullName).Success == false ||
               model.Email.Length < 3 ||
               model.Email.Length > 30))
            {
                return this.BadRequestErrorWithView("Invalid registration information format!");
            }
            if (this.DbContext.Users.Any(user => user.Email == model.Email))
            {
                return this.BadRequestErrorWithView("Email is already in use!");
            }
            if (hashedConfirmPassword == hashedPassword)
            {
                //Adding user to db 

                User user = new User()
                {
                    FullName = model.FullName,
                    Email = model.Email,
                    Password = hashedPassword,
                };

                if (!this.DbContext.Users.Any())
                {
                    user.Role = Role.Admin;
                }
                else
                {
                    user.Role = Role.User;

                }

                using (this.DbContext)
                {
                    if (this.DbContext.Users.Any(u => u.Email == model.Email) == true
                        ||
                        this.DbContext.Users.Any(u => u.FullName == model.FullName) == true)
                    {
                        return this.BadRequestErrorWithView("User already exists!");
                    }

                    this.DbContext.Users.Add(user);
                    this.DbContext.SaveChanges();
                }

                ////Adding cookie
                var mvcUser = new MvcUserInfo { Username = user.FullName, Role = user.Role.ToString() };
                var cookieContent = this.UserCookieService.GetUserCookie(mvcUser);
                HttpCookie cookie = new HttpCookie(AuthenticationCookieKey, cookieContent);

                this.Request.Cookies.Add(cookie);
                this.Response.Cookies.Add(cookie);

            }

            return this.Redirect("/");
        }

        [HttpPost]
        public IHttpResponse Login(PostLoginViewModel model)
        {
            string hashedPassword = this.hashService.Hash(model.Password);

            if (!(this.DbContext.Users.Any(user =>
                (user.Email == model.Email.Trim())
            && user.Password == hashedPassword))
            || model.Email.Trim().Length < 3
            || model.Password.Trim().Length < 3)
            {
                return this.BadRequestErrorWithView("Invalid user information!");
            }
            else
            {
                var user = this.DbContext.Users.First(u => u.Email == model.Email);

                //Adding cookie
                var mvcUser = new MvcUserInfo { Username = user.FullName, Role = user.Role.ToString() };
                var cookieContent = this.UserCookieService.GetUserCookie(mvcUser);
                HttpCookie cookie = new HttpCookie(AuthenticationCookieKey, cookieContent);

                this.Request.Cookies.Add(cookie);
                this.Response.Cookies.Add(cookie);
            }

            return this.Redirect("/");
        }
    }
}