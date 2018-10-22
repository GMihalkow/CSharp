namespace SIS.Services.MvcFramework
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Text;

    public class PathService
    {
        public static string HtmlFinder(string htmlName)
        {
            string result = $"../{Assembly.GetEntryAssembly().GetName(true).Name}/Resources/HTML/{htmlName}.html";
            string test = Path.GetFullPath(result);
 
            return result;
        }
    }
}