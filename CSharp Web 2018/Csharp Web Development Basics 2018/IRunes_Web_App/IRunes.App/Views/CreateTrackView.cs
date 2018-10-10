namespace IRunes.App.Views
{
    using IRunes.App.Views.Contracts;
    using SIS.Services;
    using System.IO;

    public class CreateTrackView : IView
    {
        public string View()
        {
            string createTrackBody = File.ReadAllText(PathService.HtmlFinder("create-track"));
            string layout = File.ReadAllText(PathService.HtmlFinder("_LoggedInLayout"));
            layout = layout.Replace("@Body", createTrackBody);

            return layout;
        }
    }
}