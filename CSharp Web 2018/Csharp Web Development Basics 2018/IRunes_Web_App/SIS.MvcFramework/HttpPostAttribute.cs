namespace SIS.MvcFramework
{
    using System;
    using SIS.HTTP.Enums;

    public class HttpPostAttribute : HttpAttribute
    {
        public HttpPostAttribute(string path)
            : base(path)
        {

        }

        public override HttpRequestMethod Method => HttpRequestMethod.Post;
    }
}
