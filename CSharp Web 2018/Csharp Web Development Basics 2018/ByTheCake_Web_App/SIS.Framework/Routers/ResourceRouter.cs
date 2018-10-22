namespace SIS.Framework.Routers
{
    using SIS.HTTP.Enums;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses;
    using SIS.WebServer.Api.Contracts;
    using SIS.WebServer.Results;
    using System.IO;
    using System.Net;
    using System.Reflection;

    public class ResourceRouter : IHttpHandler
    {
        private const string NotFoundError = "<h1>Error 404 Not Found!</h1>";

        private IHttpRequest request;

        public IHttpResponse Handle(IHttpRequest request)
        {
            this.request = request;

            return this.ReturnIfResource(request.Path);
        }

        private IHttpResponse ReturnIfResource(string path)
        {
            path = $"/{Assembly.GetEntryAssembly().GetName(true).Name}/Resources" + path;
            string fixedPath = WebUtility.UrlDecode(path);
            string fullPath = Path.GetFullPath(".." + fixedPath);

            if (File.Exists(fullPath))
            {
                byte[] resourceFileContent = File.ReadAllBytes(fullPath);
                return new InlineResourceResult(resourceFileContent, HttpResponseStatusCode.Ok);
            }
            else
            {
                return new HtmlResult(NotFoundError, HttpResponseStatusCode.NotFound);
            }
        }
    }
}
