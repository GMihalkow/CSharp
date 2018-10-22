namespace SIS.MvcFramework
{
    using SIS.HTTP.Enums;
    using SIS.HTTP.Headers;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses;
    using SIS.HTTP.Responses.Contracts;
    using SIS.MvcFramework.Contracts.Services;
    using SIS.MvcFramework.Logger;
    using SIS.MvcFramework.Services;
    using SIS.MvcFramework.ViewEngine.Contracts;
    using SIS.Services.MvcFramework;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Controller
    {
        protected const string EncryptKey = "186fd62b-5806-4b7b-8f76-3b04ad02bee3";

        protected const string AuthenticationCookieKey = "-auth.irunes";

        protected Controller()
        {
            this.ViewEngine = new SIS.MvcFramework.ViewEngine.ViewEngine();
            this.Response = new HttpResponse();
            this.UserCookieService = new UserCookieService(new FileLogger("log.txt"));
        }

        public IViewEngine ViewEngine { get; set; }

        public IHttpRequest Request { get; set; }

        public IHttpResponse Response { get; set; }

        public IUserCookieService UserCookieService { get; internal set; }

        protected IHttpResponse View<T>(string viewName, HttpResponseStatusCode statusCode, T model = null)
            where T : class
        {
            var allContent = this.GetViewContent(viewName, model);
            this.PrepareHtmlResult(allContent);
            this.Response.StatusCode = statusCode;

            return this.Response;
        }

        protected string User
        {
            get
            {
                if (!this.Request.Cookies.ContainsCookie(AuthenticationCookieKey))
                {
                    return null;
                }

                var cookie = this.Request.Cookies.GetCookie(AuthenticationCookieKey);
                var cookieContent = cookie.Value;
                var userName = this.UserCookieService.GetUserData(cookieContent, EncryptKey);

                return userName;
            }
        }

        protected IHttpResponse File(byte[] content)
        {
            this.Response.Headers.Add(new HttpHeader(HttpHeader.ContentLength, content.Length.ToString()));
            this.Response.Headers.Add(new HttpHeader(HttpHeader.ContentDisposition, "inline"));
            this.Response.Content = content;
            return this.Response;
        }

        protected IHttpResponse Redirect(string location)
        {
            this.Response.Headers.Add(new HttpHeader(HttpHeader.Location, location));
            this.Response.StatusCode = HttpResponseStatusCode.SeeOther;//Look up a better 
                                                                       //redirect status code

            return this.Response;
        }

        protected IHttpResponse Text(string content)
        {
            this.Response.Headers.Add(new HttpHeader(HttpHeader.ContentType, "text/plain; charset=utf-8"));
            this.Response.Content = Encoding.UTF8.GetBytes(content);

            return this.Response;
        }

        protected IHttpResponse BadRequestError(string errorMessage)
        {
            var viewBag = new Dictionary<string, string>();
            viewBag.Add("Error", errorMessage);
            var allContent = this.GetViewContent("Error", viewBag);
            this.PrepareHtmlResult(allContent);
            this.Response.StatusCode = HttpResponseStatusCode.BadRequest;

            return this.Response;
        }

        protected IHttpResponse ServerError(string errorMessage)
        {
            var viewBag = new Dictionary<string, string>();
            viewBag.Add("Error", errorMessage);
            var allContent = this.GetViewContent("Error", viewBag);

            this.PrepareHtmlResult(allContent);
            this.Response.StatusCode = HttpResponseStatusCode.InternalServerError;

            return this.Response;
        }
        //Finish implementing ViewEngine
        private string GetViewContent<T>(string viewName, T model)
        {
            string layoutContent = string.Empty;

            var content = this.ViewEngine.GetHtml(viewName,
                System.IO.File.ReadAllText(PathService.HtmlFinder(viewName)), model);

            //string content = System.IO.File.ReadAllText(PathService.HtmlFinder(viewName));

            if (this.Request.Cookies.ContainsCookie(AuthenticationCookieKey) && this.Request.Cookies.GetCookie(AuthenticationCookieKey).Expires >= DateTime.UtcNow)
            {
                layoutContent = System.IO.File.ReadAllText(PathService.HtmlFinder("_LoggedInLayout"));
            }
            else
            {
                layoutContent = System.IO.File.ReadAllText(PathService.HtmlFinder("_LoggedOutLayout"));
            }

            string allContent = layoutContent.Replace("@Body", content);
            return allContent;
        }

        private void GetLayout(string layoutContent)
        {
            if (this.Request.Cookies.ContainsCookie(AuthenticationCookieKey) && this.Request.Cookies.GetCookie(AuthenticationCookieKey).Expires >= DateTime.UtcNow)
            {
                layoutContent = System.IO.File.ReadAllText(PathService.HtmlFinder("_LoggedInayout"));
            }
            else
            {
                layoutContent = System.IO.File.ReadAllText(PathService.HtmlFinder("_LoggedOutLayout"));
            }
        }

        private void PrepareHtmlResult(string content)
        {
            this.Response.Headers.Add(new HttpHeader(HttpHeader.ContentType, "text/html; charset=utf-8"));
            this.Response.Content = Encoding.UTF8.GetBytes(content);
        }
    }
}