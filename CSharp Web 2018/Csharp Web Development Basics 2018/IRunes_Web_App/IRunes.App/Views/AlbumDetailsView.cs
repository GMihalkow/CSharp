namespace IRunes.App.Views
{
    using IRunes.App.Views.Contracts;
    using SIS.Services;
    using System.IO;

    public class AlbumDetailsView : IView
    {
        public string View()
        {
            string albumBody = File.ReadAllText(PathService.HtmlFinder("album"));
            string layout = File.ReadAllText(PathService.HtmlFinder("_LoggedInLayout"));
            layout = layout.Replace("@Body", albumBody);

            return layout;
        }
    }
}
