namespace Chushka.App.Controllers.Users
{
    using Chushka.App.Models;
    using Chushka.App.Models.Enums;
    using Chushka.App.ViewModels.Users;
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class UsersController : BaseController
    {
        public IHttpResponse Login()
        {
            if (this.User.IsLoggedIn)
                return this.Redirect("/");

            return this.View();
        }

        [HttpPost]
        public IHttpResponse Login(UserLoginViewModel model)
        {
            string hashedPassword = this.HashService.Hash(model.Password);

            if (!(this.DbContext.Users.Any(user => (user.Username == model.Username.Trim())
            && user.Password == hashedPassword))
            || model.Password.Trim().Length < 3)
            {
                return this.BadRequestErrorWithView("Invalid user information!");
            }
            else
            {
                var user = this.DbContext.Users.First(u => u.Username == model.Username);

                //Adding cookie
                var mvcUser = new MvcUserInfo { Username = user.Username, Role = user.Role.ToString(), Info = user.FullName };
                var cookieContent = this.UserCookieService.GetUserCookie(mvcUser);
                HttpCookie cookie = new HttpCookie(AuthenticationCookieKey, cookieContent);

                this.Request.Cookies.Add(cookie);
                this.Response.Cookies.Add(cookie);
            }

            return this.Redirect("/");
        }

        public IHttpResponse Register()
        {
            if (this.User.IsLoggedIn)
                return this.Redirect("/");

            return this.View();
        }

        [HttpPost]
        public IHttpResponse Register(UserRegisterViewModel model)
        {
            Regex usernameAndPasswordRegex = new Regex(@"^\w+$");
            Regex emailRegex = new Regex(@"^[A-z]+\@[A-z]+\.[A-z]{1,4}$");

            string hashedPassword = this.HashService.Hash(model.Password);
            string hashedConfirmPassword = this.HashService.Hash(model.ConfirmPassword);

            model.Email = StringExtensions.UrlDecode(model.Email);

            if (usernameAndPasswordRegex.Match(model.Username).Success == false ||
                emailRegex.Match(model.Email).Success == false ||
                usernameAndPasswordRegex.Match(model.Password).Success == false ||
                model.Password.Length < 3 ||
                model.Username.Length < 3 ||
                model.Username.Length > 50 ||
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
                    Username = model.Username,
                    FullName = model.FullName,
                    Email = model.Email,
                    Password = hashedPassword,
                };

                if (!this.DbContext.Users.Any())
                {
                    user.Role = UserRole.Admin;
                }
                else
                {
                    user.Role = UserRole.User;

                }

                using (this.DbContext)
                {
                    if (this.DbContext.Users.Any(u => u.Email == model.Email) == true
                        ||
                        this.DbContext.Users.Any(u => u.Username == model.Username) == true)
                    {
                        return this.BadRequestErrorWithView("User already exists!");
                    }

                    this.DbContext.Users.Add(user);
                    this.DbContext.SaveChanges();
                }

                ////Adding cookie
                var mvcUser = new MvcUserInfo { Username = user.Username, Role = user.Role.ToString(), Info = user.FullName };
                var cookieContent = this.UserCookieService.GetUserCookie(mvcUser);
                HttpCookie cookie = new HttpCookie(AuthenticationCookieKey, cookieContent);

                this.Request.Cookies.Add(cookie);
                this.Response.Cookies.Add(cookie);
            }

            return this.Redirect("/");
        }

        [Authorize]
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
                return this.Redirect("/");
            }
        }
    }
}