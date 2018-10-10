namespace SIS.HTTP.Extensions
{
    using SIS.HTTP.Enums;

    public class HttpResponseStatusExtensions
    {
        public static string GetResponseLine(HttpResponseStatusCode statusCode)
        {
            return $"{(int)statusCode} {statusCode.ToString()}";
        }
    }
}
