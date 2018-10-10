namespace IRunes.App.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Text.RegularExpressions;
    using IRunes.App.Views;
    using IRunes.Models;
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses;
    using SIS.HTTP.Responses.Contracts;
    using SIS.WebServer.Results;

    public class AccountController : BaseController
    {
        private const string InvalidRegisterInformationMessage = "<p style=\"text-align:center;\">Invalid password/username/email, please try again!</p>";

        private const string InvalidLoginInformationMessage = "<p style=\"text-align:center;\">Invalid username/password combination!<p>";

        private const string UsernameAlreadyExistsErrorMessage = "<p style=\"text-align:center;\">Username already exists!</p>";

        public IHttpResponse GetLogin(IHttpRequest request)
        {
            if (request.Cookies.ContainsCookie(AuthenticationCookieKey))
            {
                string username = EncryptService.Decrypt(request.Cookies.GetCookie(AuthenticationCookieKey).Value, EncryptKey);

                string loggedInView = new LoggedInView().View();
                loggedInView = loggedInView.Replace("{{{name}}}", username);
                return new HtmlResult(loggedInView, HttpResponseStatusCode.Ok);
            }

            string loginView = new LoginView().View();
            loginView = loginView.Replace("{{{error}}}", string.Empty);

            IHttpResponse response = new HtmlResult(loginView, HttpResponseStatusCode.Ok);

            return response;
        }

        public IHttpResponse PostLogin(IHttpRequest request)
        {
            string usernameOrEmail = WebUtility.UrlDecode(request.FormData["username-or-email"].ToString().Trim());
            string password = this.HashService.Compute256Hash(request.FormData["password"].ToString().Trim());

            string username =
                this.Context
                .Users
                .Where(user => user.Username == usernameOrEmail || user.Email == usernameOrEmail)
                .First()
                .Username;

            string view = new LoggedInView().View();
            view = view.Replace("{{{name}}}", username);

            if (this.Context.Users.Any(user => (user.Username == usernameOrEmail || user.Email == usernameOrEmail) && user.Password == password))
            {
                IHttpResponse response = new HtmlResult(view, HttpResponseStatusCode.Ok);
                HttpCookie cookie = new HttpCookie(AuthenticationCookieKey, this.EncryptService.Encrypt(usernameOrEmail, EncryptKey));

                request.Cookies.Add(cookie);
                response.Cookies.Add(cookie);

                return response;
            }
            else
            {
                string errorView = new LoginView().View();
                errorView = errorView.Replace("{{{error}}}", InvalidLoginInformationMessage);

                return new HtmlResult(errorView, HttpResponseStatusCode.BadRequest);
            }
        }

        public IHttpResponse GetRegister(IHttpRequest request)
        {
            string registerView = new RegisterView().View();
            registerView = registerView.Replace("{{{error}}}", string.Empty);

            var response = new HtmlResult(registerView, HttpResponseStatusCode.Ok);

            HttpCookie cookie;

            if (request.Cookies.ContainsCookie(AuthenticationCookieKey))
            {
                request.Cookies.GetCookie(AuthenticationCookieKey).Delete();

                cookie = request.Cookies.GetCookie(AuthenticationCookieKey);

                response.AddCookie(cookie);
            }

            return response;
        }

        public IHttpResponse PostRegister(IHttpRequest request)
        {
            Regex usernameAndPasswordRegex = new Regex(@"^\w+$");
            Regex emailRegex = new Regex(@"^[A-z]+\@[A-z]+\.[A-z]{1,4}$");

            string username = request.FormData["username"].ToString();
            string rawPassword = request.FormData["password"].ToString();

            string hashedPassword = this.HashService.Compute256Hash(rawPassword);
            string hashedConfirmPassword = this.HashService.Compute256Hash(rawPassword);

            string email = request.FormData["email"].ToString();
            email = email.Replace("%40", "@");

            if (emailRegex.Match(email).Success == false ||
                usernameAndPasswordRegex.Match(rawPassword).Success == false ||
                rawPassword.Length < 3 ||
                rawPassword.Length > 50 ||
               (usernameAndPasswordRegex.Match(username).Success == false ||
               username.Length < 3 ||
               username.Length > 30))
            {
                string registerView = new RegisterView().View();
                registerView = registerView.Replace("{{{error}}}", InvalidRegisterInformationMessage);

                return new HtmlResult(registerView, HttpResponseStatusCode.BadRequest);
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
                        string registerView = new RegisterView().View();
                        registerView = registerView.Replace("{{{error}}}", UsernameAlreadyExistsErrorMessage);

                        return new HtmlResult(registerView, HttpResponseStatusCode.BadRequest);
                    }

                    this.Context.Users.Add(user);
                    this.Context.SaveChanges();
                }
            }

            string view = new LoggedInView().View();
            view = view.Replace("{{{name}}}", username);

            //Adding cookie
            IHttpResponse response = new HtmlResult(view, HttpResponseStatusCode.Ok);
            HttpCookie cookie = new HttpCookie(AuthenticationCookieKey, this.EncryptService.Encrypt(username, EncryptKey));

            request.Cookies.Add(cookie);
            response.Cookies.Add(cookie);

            return response;
        }
    }
}