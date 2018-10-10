namespace IRunes.App.Controllers
{
    using IRunes.App.Views;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;
    using SIS.WebServer.Results;
    using SIS.WebServer.Routing;

    public class HomeController : BaseController
    {
        public IHttpResponse Index(IHttpRequest request)
        {
            IHttpResponse response;

            if (request.Cookies.ContainsCookie(AuthenticationCookieKey))
            {
                if (request.Cookies.ContainsCookie(AuthenticationCookieKey))
                {
                    string username = EncryptService.Decrypt(request.Cookies.GetCookie(AuthenticationCookieKey).Value, EncryptKey);

                    string view = new LoggedInView().View();
                    view = view.Replace("{{{name}}}", username);
                    return new HtmlResult(view, HttpResponseStatusCode.Ok);
                }

                response = new HtmlResult(new LoginView().View(), HttpResponseStatusCode.Ok);

                return response;
            }
            else
            {
                return new HtmlResult(new HomeView().View(), HttpResponseStatusCode.Ok);
            }
        }
    }
}