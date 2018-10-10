namespace IRunes.App.Views
{
    using IRunes.App.Views.Contracts;
    using SIS.Services;
    using System;
    using System.IO;

    public class LoggedInView : IView
    {
        public string View()
        {
            string loggedInBody = File.ReadAllText(PathService.HtmlFinder("Logged")); ;
            string layout = File.ReadAllText(PathService.HtmlFinder("_LoggedInLayout"));
            layout = layout.Replace("@Body", loggedInBody);

            return layout;
        }
    }
}