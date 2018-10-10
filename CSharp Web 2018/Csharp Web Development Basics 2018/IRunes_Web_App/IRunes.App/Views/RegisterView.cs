namespace IRunes.App.Views
{
    using IRunes.App.Views.Contracts;
    using SIS.Services;
    using System;
    using System.IO;

    public class RegisterView : IView
    {
        public string View()
        {
            string registerBody = File.ReadAllText(PathService.HtmlFinder("Register"));
            string layout = File.ReadAllText(PathService.HtmlFinder("_LoggedOutLayout"));
            layout = layout.Replace("@Body", registerBody);

            return layout;
        }
    }
}
