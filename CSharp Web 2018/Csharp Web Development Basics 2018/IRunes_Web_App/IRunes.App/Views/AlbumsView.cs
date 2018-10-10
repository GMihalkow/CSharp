namespace IRunes.App.Views
{
    using IRunes.App.Views.Contracts;
    using SIS.Services;
    using System.IO;

    public class AlbumsView : IView
    {
        public string View()
        {
            string allAlbumsBody = File.ReadAllText(PathService.HtmlFinder("all-albums"));
            string layout = File.ReadAllText(PathService.HtmlFinder("_LoggedInLayout"));
            layout = layout.Replace("@Body", allAlbumsBody);

            return layout;
        }
    }
}