namespace SIS.HTTP.Exceptions
{
    using System;

    public class BadRequestException : Exception
    {
        public BadRequestException(string message = "The Request was malformed or contains unsupported elements.")
            : base(message)
        {

        }
    }
}
