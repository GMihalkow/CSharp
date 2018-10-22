namespace SIS.MvcFramework.Logger
{
    using System;

    public class ConsoleLogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[{DateTime.UtcNow}] {message}");
        }
    }
}