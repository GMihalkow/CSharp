using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using SIS.HTTP.Common;
using SIS.HTTP.Enums;
using SIS.HTTP.Requests;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses;
using SIS.WebServer.Api.Contracts;
using SIS.WebServer.Results;
using SIS.WebServer.Routing;

namespace SIS.Framework
{
    public class HttpHandler : IHttpHandler
    {
        private const string RootDirectoryRelativePath = "../../..";
        private ServerRoutingTable serverRoutingTable;

        public HttpHandler(ServerRoutingTable routingTable)
        {
            this.serverRoutingTable = routingTable;
        }

        public IHttpResponse Handle(IHttpRequest httpRequest)
        {
            var isResourceRequest = this.IsResourceRequest(httpRequest);
            if (isResourceRequest)
            {
                return this.ReturnIfResource(httpRequest.Path);
            }
            if (!this.serverRoutingTable.Routes.ContainsKey(httpRequest.RequestMethod)
                || !this.serverRoutingTable.Routes[httpRequest.RequestMethod].ContainsKey(httpRequest.Path.ToLower()))
            {
                return new HttpResponse(HttpResponseStatusCode.NotFound);
            }

            return this.serverRoutingTable.Routes[httpRequest.RequestMethod][httpRequest.Path].Invoke(httpRequest);
        }

        private bool IsResourceRequest(IHttpRequest httpRequest)
        {
            var requestPath = httpRequest.Path;
            if (requestPath.Contains('.'))
            {
                var requestPathExtension = requestPath
                    .Substring(requestPath.LastIndexOf('.'));
                return GlobalConstants.ResourceExtensions.Contains(requestPathExtension);
            }
            return false;
        }

        private IHttpResponse ReturnIfResource(string path)
        {
            path = $"/{Assembly.GetEntryAssembly().GetName(true).Name}/Resources/" + path;
            string fixedPath = WebUtility.UrlDecode(path);
            string fullPath = Path.GetFullPath(".." + fixedPath);

            if (File.Exists(fullPath))
            {
                byte[] resourceFileContent = File.ReadAllBytes(fullPath);
                return new InlineResourceResult(resourceFileContent, HttpResponseStatusCode.Ok);
            }
            else
            {
                return new HtmlResult("<h1>Error 404 Not Found!</h1>", HttpResponseStatusCode.NotFound);
            }
        }
        private IHttpResponse HandleRequestResponse(string httpRequestPath)
        {
            var indexOfStartOfExtension = httpRequestPath.LastIndexOf('.');
            var indexOfStartOfNameOfResource = httpRequestPath.LastIndexOf('/');

            var requestPathExtension = httpRequestPath
                .Substring(indexOfStartOfExtension);

            var resourceName = httpRequestPath
                .Substring(
                    indexOfStartOfNameOfResource);

            var resourcePath = RootDirectoryRelativePath
                               + "/Resources"
                               + $"/{requestPathExtension.Substring(1)}"
                               + resourceName;

            if (!File.Exists(resourcePath))
            {
                return new HttpResponse(HttpResponseStatusCode.NotFound);
            }

            var fileContent = File.ReadAllBytes(resourcePath);

            return new InlineResouceResult(fileContent, HttpResponseStatusCode.Ok);
        }
    }
}
