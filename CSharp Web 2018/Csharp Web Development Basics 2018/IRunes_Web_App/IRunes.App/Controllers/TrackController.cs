namespace IRunes.App.Controllers
{
    using IRunes.App.Views;
    using IRunes.Models;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses;
    using SIS.HTTP.Responses.Contracts;
    using SIS.WebServer.Results;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Text.RegularExpressions;

    public class TrackController : BaseController
    {
        private const string InvalidTrackInformationError = "<p style=\"text-align:center;\">Invalid name/url/price information!</p>";

        private const string TrackAlreadyExistsError = "<p style=\"text-align:center;\">This track already exists!</p>";

        public IHttpResponse CreateTrack(IHttpRequest request)
        {
            string albumId = request.QueryData["albumId"].ToString();

            string path = WebUtility.UrlDecode($"/Albums/Details?id={albumId}");
            string postPath = WebUtility.UrlDecode($"/Tracks/Create?albumId={albumId}");
            var view = new CreateTrackView().View();
            view = view.Replace(WebUtility.UrlDecode(@"\{\{\{back-to-album}}}"), path);
            view = view.Replace("{{{create-path}}}", postPath);
            view = view.Replace("{{{error}}}", string.Empty);

            return new HtmlResult(view, HttpResponseStatusCode.Ok);
        }

        public IHttpResponse PostCreateTrack(IHttpRequest request)
        {
            Regex trackNameRegex = new Regex(@"^\w{3,30}$");
            Regex linkUrlRegex = new Regex(@"^\b((http|https):\/\/?)[^\s()<>]+(?:\([\w\d]+\)|([^[:punct:]\s]|\/?))$");

            string albumId = request.QueryData["albumId"].ToString();

            string backToAlbumPath = WebUtility.UrlDecode($"/Albums/Details?id={albumId}");

            string trackName = request.FormData["name"].ToString();
            string trackLink = WebUtility.UrlDecode(request.FormData["link"].ToString());
            decimal trackPrice = 0;

            bool IsDecimal = decimal.TryParse(request.FormData["price"].ToString(), out trackPrice);

            Track track = new Track()
            {
                Id = Guid.NewGuid().ToString(),
                Name = trackName,
                Price = trackPrice,
                Link = trackLink
            };

            AlbumTrack albumTrack = new AlbumTrack()
            {
                AlbumId = albumId,
                TrackId = track.Id
            };
            
            if (!IsDecimal
                ||
                !linkUrlRegex.Match(trackLink).Success
                ||
                !trackNameRegex.Match(trackName).Success
                ||
                track.Price < 0
                )
            {

                string createTrackView = new CreateTrackView().View();
                createTrackView = createTrackView.Replace(@"\{\{\{back-to-album}}}", backToAlbumPath);
                createTrackView = createTrackView.Replace("{{{error}}}", InvalidTrackInformationError);
                createTrackView = createTrackView.Replace(@"{{{create-path}}}", WebUtility.UrlDecode($"/Tracks/Create?albumId={albumId}"));

                return new HtmlResult(createTrackView, HttpResponseStatusCode.BadRequest);

            }
            else if (this.Context.AlbumTracks.Where(at => at.AlbumId == albumId).Any(tr => tr.Track.Name == trackName))
            {
                string createTrackView = new CreateTrackView().View();
                createTrackView = createTrackView.Replace(@"\{\{\{back-to-album}}}", backToAlbumPath);
                createTrackView = createTrackView.Replace("{{{error}}}", TrackAlreadyExistsError);
                createTrackView= createTrackView.Replace(@"{{{create-path}}}", WebUtility.UrlDecode($"/Tracks/Create?albumId={albumId}"));

                return new HtmlResult(createTrackView, HttpResponseStatusCode.BadRequest);
            }

            using (this.Context)
            {
                this.Context
                    .Add(track);

                this.Context
                    .Add(albumTrack);

                this.Context
                    .Albums
                    .First(album => album.Id == albumId)
                    .Tracks
                    .Add(albumTrack);

                this.Context
                    .SaveChanges();
            }

            string view = new TrackDetailsView().View();
            view = view.Replace("{{{link}}}", track.Link);
            view = view.Replace("{{{name}}}", track.Name);
            view = view.Replace("{{{price}}}", $"${track.Price.ToString(CultureInfo.InvariantCulture):f2}");
            view = view.Replace(WebUtility.UrlDecode(@"\{\{\{back-to-album}}}"), backToAlbumPath);
            view = view.Replace(@"{{{create-path}}}", WebUtility.UrlDecode($"/Tracks/Create?albumId={albumId}"));

            return new HtmlResult(view, HttpResponseStatusCode.Ok);
        }

        public IHttpResponse TrackDetails(IHttpRequest request)
        {
            string view = new TrackDetailsView().View();

            string albumId = request.QueryData["albumId"].ToString();
            string trackId = request.QueryData["trackId"].ToString();

            string backtoAlbumPath = WebUtility.UrlDecode($"/Albums/Details?id={albumId}");

            Track track = this.Context
                .Tracks
                .First(tr => tr.Id == trackId);

            view = view.Replace("{{{link}}}", track.Link);
            view = view.Replace("{{{name}}}", track.Name);
            view = view.Replace("{{{price}}}", $"${track.Price:f2}");
            view = view.Replace(WebUtility.UrlDecode(@"\{\{\{back-to-album}}}"), backtoAlbumPath);

            return new HtmlResult(view, HttpResponseStatusCode.Ok);
        }
    }
}