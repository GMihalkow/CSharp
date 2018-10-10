namespace IRunes.App.Views
{
    using IRunes.App.Views.Contracts;
    using SIS.Services;
    using System.IO;

    public class CreateAlbumView : IView
    {
        public string View()
        {
            string albumsCreateBody = File.ReadAllText(PathService.HtmlFinder("Albums-Create"));
            string layout = File.ReadAllText(PathService.HtmlFinder("_LoggedInLayout"));
            layout = layout.Replace("@Body", albumsCreateBody);

            return layout;
        }
    }
}
