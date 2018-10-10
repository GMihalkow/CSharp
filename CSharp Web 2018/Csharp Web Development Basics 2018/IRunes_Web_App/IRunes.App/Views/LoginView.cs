namespace IRunes.App.Views
{
    using IRunes.App.Views.Contracts;
    using SIS.Services;
    using System.IO;

    public class LoginView : IView
    {
        public string View()
        {
            string loginBody = File.ReadAllText(PathService.HtmlFinder("Login"));
            string layout = File.ReadAllText(PathService.HtmlFinder("_LoggedOutLayout"));
            layout = layout.Replace("@Body", loginBody);

            return layout;
        }
    }
}
