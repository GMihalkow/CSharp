namespace IRunes.App.Views
{
    using IRunes.App.Views.Contracts;
    using SIS.Services;
    using System.IO;

    public class TrackDetailsView : IView
    {
        public string View()
        {
            string trackDetailsBody = File.ReadAllText(PathService.HtmlFinder("track"));
            string layout = File.ReadAllText(PathService.HtmlFinder("_LoggedInLayout"));
            layout = layout.Replace("@Body", trackDetailsBody);

            return layout;
        }
    }
}