namespace ByTheCakeApp.ByTheCakeApplication.Exceptions
{
    using System;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Responses;
    using SIS.WebServer.Results;

    public class InvalidAccountResponse : HtmlResult
    {
        public InvalidAccountResponse(string content = @"<h1>Passwords don't match!</h1> <a href=""/register"">Back</a>", HttpResponseStatusCode statusCode = HttpResponseStatusCode.BadRequest)
            : base(content, statusCode)
        {
        }
    }
}