namespace SIS.Services.MvcFramework
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PathService
    {
        public static string HtmlFinder(string htmlName)
        {
            return $"../IRunes.App/Resources/HTML/{htmlName}.html";
        }
    }
}