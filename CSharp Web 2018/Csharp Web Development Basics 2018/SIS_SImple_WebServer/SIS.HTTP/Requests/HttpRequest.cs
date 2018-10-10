namespace SIS.HTTP.Requests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Exceptions;
    using SIS.HTTP.Extensions;
    using SIS.HTTP.Headers;
    using SIS.HTTP.Headers.Contracts;
    using SIS.HTTP.Requests.Contracts;

    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new HttpHeaderCollection();

            this.ParseRequest(requestString);
        }

        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, object> FormData { get; }

        public Dictionary<string, object> QueryData { get; }

        public IHttpHeaderCollection Headers { get; }

        public HttpRequestMethod RequestMethod { get; private set; }

        private void ParseRequest(string requestString)
        {
            string[] splitRequestContent = requestString
                .Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            string[] requestLine = splitRequestContent[0].Trim().
                Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (!this.IsValidRequestLine(requestLine))
            {
                throw new BadRequestException();
            }

            this.ParseRequestMethod(requestLine);
            this.ParseRequestUrl(requestLine);
            this.ParseRequestPath();

            this.ParseHeaders(splitRequestContent.Skip(1).ToArray());
            
        }

        private bool IsValidRequestLine(string[] requestLine)
        {
            if (requestLine.Length == 3 && requestLine[2] == "HTTP/1.1")
                return true;
            else
                return false;
        }

        private void ParseRequestMethod(string[] requestLine)
        {
            string method = StringExtensions.Capitalize(requestLine[0]);

            var parsedRequestMethod = (HttpRequestMethod)Enum.Parse(typeof(HttpRequestMethod), method);

            this.RequestMethod = parsedRequestMethod;
        }

        private void ParseRequestUrl(string[] requestLine)
        {
            this.Url = requestLine[1];
        }

        private void ParseRequestPath()
        {
            string[] urlChunks = this.Url
                .Split(new[] { "?", "&", "#" }, StringSplitOptions.RemoveEmptyEntries);

            string path = urlChunks[0];

            this.Path = path;
        }

        private void ParseHeaders(string[] headers)
        {
            int endIndex = Array.IndexOf(headers, string.Empty);

            for (int index = 0; index < endIndex; index++)
            {
                string[] headerChunks =
                    headers[index]
                    .Split(new string[] { ": " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string key = headerChunks[0];
                string value = headerChunks[1];

                HttpHeader header = new HttpHeader(key, value);
                this.Headers.Add(header);
            }

            if (!this.Headers.ContainsHeader("Host"))
                throw new BadRequestException();
        }

        private bool IsValidRequestQueryString(string queryString)
        {
            if (queryString != null && queryString != string.Empty && queryString.Contains("="))
            {
                return true;
            }
            else
                throw new BadRequestException();
        }

        private void ParseQueryParameters()
        {
            string queryString =
                this.Url
                .Split(new[] { "?", "#" }, StringSplitOptions.RemoveEmptyEntries)
                [1];

            if (!IsValidRequestQueryString(queryString))
                return;

            string[] queryLines =
                queryString
                .Split(new[] { "&" }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int index = 0; index < queryLines.Length; index++)
            {
                string[] queryParameters =
                    queryLines[index]
                    .Split(new[] { "=" }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                this.QueryData.Add(queryParameters[0], queryParameters);
            }
        }

        private void ParseFormDataParameters()
        {
            string queryString =
                this.Url
                .Split(new[] { "?", "#" }, StringSplitOptions.RemoveEmptyEntries)
                [1];

            if (!IsValidRequestQueryString(queryString))
                return;

            string[] queryLines =
                queryString
                .Split(new[] { "&" }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int index = 0; index < queryLines.Length; index++)
            {
                string[] queryParameters =
                    queryLines[index]
                    .Split(new[] { "=" }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                this.FormData.Add(queryParameters[0], queryParameters);
            }
        }

        private void ParseRequestParameters()
        {
            ParseQueryParameters();
            ParseFormDataParameters();
        }
    }
}
