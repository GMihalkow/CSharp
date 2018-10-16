using SIS.HTTP.Requests;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses;

namespace SIS.WebServer.Api.Contracts
{
    public interface IHttpHandler
    {
        IHttpResponse Handle(IHttpRequest request);
    }
}
