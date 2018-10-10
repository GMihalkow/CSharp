namespace SIS.HTTP.Responses
{
    using SIS.HTTP.Common;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Extensions;
    using SIS.HTTP.Headers;
    using SIS.HTTP.Headers.Contracts;
    using SIS.HTTP.Responses.Contracts;
    using System;
    using System.Linq;
    using System.Text;

    public class HttpResponse : IHttpResponse
    {
        public HttpResponse() { }

        public HttpResponse(HttpResponseStatusCode statusCode)
        {
            this.Headers = new HttpHeaderCollection();
            this.Content = new byte[0];
            this.StatusCode = statusCode;
        }

        public HttpResponseStatusCode StatusCode { get; set; }

        public IHttpHeaderCollection Headers { get; }

        public byte[] Content { get; set; }

        public void AddHeader(HttpHeader header)
        {
            this.Headers.Add(header);
        }

        public byte[] GetBytes()
        {
            byte[] resultBytes = Encoding.ASCII.GetBytes(this.ToString()).ToArray();

            byte[] newLine = Encoding.ASCII.GetBytes(Environment.NewLine).ToArray();

            var tempBytes = new byte[resultBytes.Length + this.Content.Length + newLine.Length];

            resultBytes.CopyTo(tempBytes, 0);
            this.Content.CopyTo(tempBytes, resultBytes.Length);
            newLine.CopyTo(tempBytes, (this.Content.Length + resultBytes.Length));

            this.Content = tempBytes.ToArray();

            return this.Content;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result
                .Append($"{GlobalConstants.HttpOneProtocolFragment} {HttpResponseStatusExtensions.GetResponseLine(this.StatusCode)}")
                .Append(Environment.NewLine)
                .Append($"{this.Headers.ToString()}")
                .Append(Environment.NewLine)
                .Append(Environment.NewLine);

            return result.ToString();
        }
    }
}
