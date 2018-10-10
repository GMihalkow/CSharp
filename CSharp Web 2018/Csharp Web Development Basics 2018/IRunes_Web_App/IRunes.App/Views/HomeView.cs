namespace IRunes.App.Views
{
    using IRunes.App.Views.Contracts;
    using SIS.Services;
    using System.IO;

    public class HomeView : IView
    {
        public string View()
        {
            string indexBody = File.ReadAllText(PathService.HtmlFinder("Index")); ;
            string layout = File.ReadAllText(PathService.HtmlFinder("_LoggedOutLayout"));
            layout = layout.Replace("@Body", indexBody);

            return layout;
        }
    }
}
