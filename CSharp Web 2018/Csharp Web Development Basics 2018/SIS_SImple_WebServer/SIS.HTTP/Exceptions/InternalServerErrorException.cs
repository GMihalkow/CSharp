namespace SIS.HTTP.Exceptions
{
    using System;

    public class InternalServerErrorException : Exception
    {
        public InternalServerErrorException(string message = "The Server has encountered an error.")
            : base(message)
        {
        }
    }
}
