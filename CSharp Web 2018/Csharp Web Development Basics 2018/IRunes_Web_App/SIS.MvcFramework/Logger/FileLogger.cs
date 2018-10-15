namespace SIS.MvcFramework.Logger
{
    using SIS.MvcFramework.Logger.Contacts;
    using System;
    using System.IO;

    public class FileLogger : ILogger
    {
        private static readonly object LockObject = new object();

        private readonly string fileName;

        public FileLogger()
        {
            this.fileName = "log.txt";
        }

        public void Log(string message)
        {
            lock (LockObject)
            {
                File.AppendAllText(this.fileName, $"[{DateTime.UtcNow}] {message}{Environment.NewLine}");
            }
        }
    }
}