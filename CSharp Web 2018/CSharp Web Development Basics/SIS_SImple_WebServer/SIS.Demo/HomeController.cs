namespace SIS.Demo
{
    using SIS.HTTP.Enums;
    using SIS.HTTP.Responses.Contracts;
    using SIS.WebServer.Results;

    public class HomeController
    {
        public IHttpResponse Index()
        {
            string result = "<h1>Hello World!</h1>";
            return new HtmlResult(result, HttpResponseStatusCode.Ok);
        }
    }
}
