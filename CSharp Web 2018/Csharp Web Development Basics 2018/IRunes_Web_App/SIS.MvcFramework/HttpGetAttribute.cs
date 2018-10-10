namespace SIS.MvcFramework
{
    using System;
    using SIS.HTTP.Enums;

    public class HttpGetAttribute : HttpAttribute
    {
        public HttpGetAttribute(string path)
            : base(path)
        {

        }

        public override HttpRequestMethod Method => HttpRequestMethod.Get;
    }
}
