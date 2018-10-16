namespace ByTheCake.App.Controllers
{
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Requests.Contracts;
    using ByTheCake.Models;
    using System.Linq;
    using SIS.Framework.Attributes.Methods;
    using SIS.Framework.ActionsResults.Base;
    using System.Collections.Generic;
    using SIS.Framework.Services;
    using System.Text.RegularExpressions;
    using System.Text;

    public class UsersController : BaseController
    {
        private const string UsernameAlreadyExistsError =
            "<div class=\"alert alert-danger\" style=\"text-align:center\">" +
            "<strong>Warning!</strong> Username already exists!" +
            "</div>";

        private const string InvalidUsernameOrPasswordFormatError =
            "<div class=\"alert alert-danger\" style=\"text-align:center\">" +
            "<strong>Warning!</strong> Invalid username/password format!" +
            "</div>";

        private const string InvalidLoginError =
            "<div class=\"alert alert-danger\" style=\"text-align:center\">" +
            "<strong>Warning!</strong> Invalid username and password combination!" +
            "</div>";

        [HttpGet]
        public IActionResult Profile(IHttpRequest request)
        {
            string cookieData = request.Cookies.GetCookie("-auth").Value.ToString();

            string username = cookieService.GetUserData(cookieData, EncryptKey);

            User user =
                this.DbContext
                .Users
                .First(u => u.Username == username);

            StringBuilder sb = new StringBuilder();

            int ordersCount =
                this.DbContext
                .Orders
                .Where(order => order.UserId == user.Id)
                .ToArray()
                .Count();

            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                {"@Name", username },
                {"@RegDate", user.DateOfRegistration.ToString("R") },
                {"@OrdersCount", ordersCount.ToString() },
            };

            return this.View("profile", parameters);
        }

        [HttpGet]
        public IActionResult GetRegister(IHttpRequest request)
        {
            if (request.Cookies.ContainsCookie("-auth"))
            {
                request.Cookies.GetCookie("-auth").Delete();
            }

            return this.View("register");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return this.View("login");
        }

        [HttpPost]
        public IActionResult PostRegister(IHttpRequest request)
        {
            Regex UsernameAndPasswordRegex = new Regex(@"^\w+$");

            string username = request.FormData["username"].ToString();
            string password = this.hashService.Compute256Hash(request.FormData["password"].ToString());
            string confirmPassword = this.hashService.Compute256Hash(request.FormData["confirm-password"].ToString());

            Dictionary<string, string> parameters = new Dictionary<string, string>();

            if (this.DbContext.Users.Any(user => user.Username == username))
            {
                parameters.Add("@Error", UsernameAlreadyExistsError);
                return this.View("registration-error", parameters);
            }

            if (password == confirmPassword)
            {
                HttpCookie cookie = new HttpCookie("-auth", this.cookieService.Encrypt(username, EncryptKey));

                request.Cookies.Add(cookie);
                this.Response.AddCookie(cookie);

                if ((!UsernameAndPasswordRegex.Match(username).Success) || (!UsernameAndPasswordRegex.Match(username).Success))
                {
                    parameters.Add("@Error", InvalidUsernameOrPasswordFormatError);
                    return this.View("registration-error", parameters);
                }

                User user = new User()
                {
                    Username = username,
                    Password = password,
                    ConfirmPassword = confirmPassword
                };

                using (this.DbContext)
                {
                    this.DbContext.Users.Add(user);
                    this.DbContext.SaveChanges();
                }

                parameters.Add("@Name", user.Username);
            }

            var view = this.View("logged", parameters);

            return view;
        }

        [HttpPost]
        public IActionResult Login(IHttpRequest request)
        {
            string username = request.FormData["username"].ToString().Trim();
            string password = this.hashService.Compute256Hash(request.FormData["password"].ToString());

            if (this.DbContext.Users.Any(user => user.Username == username && user.Password == password))
            {
                request.Cookies.Add(new HttpCookie("-auth", this.cookieService.Encrypt(username, EncryptKey)));

                Dictionary<string, string> parameters = new Dictionary<string, string>()
                {
                    {"@Name", username }
                };

                return this.View("logged", parameters);
            }
            else
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>()
                {
                    {"@Error", InvalidLoginError}
                };

                return this.View("login-error", parameters);
            }
        }
    }
}