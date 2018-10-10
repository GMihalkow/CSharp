namespace IRunes.App.Controllers
{
    using IRunes.App.Views;
    using IRunes.Models;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses;
    using SIS.HTTP.Responses.Contracts;
    using SIS.MvcFramework;
    using SIS.WebServer.Results;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Text.RegularExpressions;

    public class TrackController : BaseController
    {
        private const string InvalidTrackInformationError = "<p style=\"text-align:center;\">Invalid name/url/price information!</p>";

        private const string TrackAlreadyExistsError = "<p style=\"text-align:center;\">This track already exists!</p>";

        [HttpGetAttribute("/Tracks/Create")]
        public IHttpResponse CreateTrack()
        {
            string albumId = this.Request.QueryData["albumId"].ToString();

            string path = WebUtility.UrlDecode($"/Albums/Details?id={albumId}");
            string postPath = WebUtility.UrlDecode($"/Tracks/Create?albumId={albumId}");

            Dictionary<string, string> createTrackParameters = new Dictionary<string, string>()
            {
                {WebUtility.UrlDecode(@"\{\{\{back-to-album}}}"), path},
                {"{{{create-path}}}", postPath },
                {"{{{error}}}", string.Empty }
            };

            return this.View("create-track", HttpResponseStatusCode.Ok, createTrackParameters);
        }

        [HttpPostAttribute("/Tracks/Create")]
        public IHttpResponse PostCreateTrack()
        {
            Regex trackNameRegex = new Regex(@"^\w{3,30}$");
            Regex linkUrlRegex = new Regex(@"^\b((http|https):\/\/?)[^\s()<>]+(?:\([\w\d]+\)|([^[:punct:]\s]|\/?))$");

            string albumId = this.Request.QueryData["albumId"].ToString();

            string backToAlbumPath = WebUtility.UrlDecode($"/Albums/Details?id={albumId}");

            string trackName = this.Request.FormData["name"].ToString();
            string trackLink = WebUtility.UrlDecode(this.Request.FormData["link"].ToString());
            decimal trackPrice = 0;

            bool IsDecimal = decimal.TryParse(this.Request.FormData["price"].ToString(), out trackPrice);

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
                Dictionary<string, string> createTrackErroParameters = new Dictionary<string, string>()
                {
                    {@"\{\{\{back-to-album}}}", backToAlbumPath },
                    {"{{{error}}}", InvalidTrackInformationError },
                    {@"{{{create-path}}}",  WebUtility.UrlDecode($"/Tracks/Create?albumId={albumId}")}
                };

                return this.View("crate-track", HttpResponseStatusCode.BadRequest, createTrackErroParameters);

            }
            else if (this.Context.AlbumTracks.Where(at => at.AlbumId == albumId).Any(tr => tr.Track.Name == trackName))
            {
                Dictionary<string, string> createTrackErrorParameters = new Dictionary<string, string>()
                {
                    {@"\{\{\{back-to-album}}}", backToAlbumPath },
                    {"{{{error}}}", TrackAlreadyExistsError },
                    {@"{{{create-path}}}",  WebUtility.UrlDecode($"/Tracks/Create?albumId={albumId}")}
                };

                return this.View("create-track", HttpResponseStatusCode.BadRequest, createTrackErrorParameters);
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

            Dictionary<string, string> trackDetailsParameters = new Dictionary<string, string>()
            {
                {"{{{link}}}", track.Link },
                {"{{{name}}}", track.Name },
                {"{{{price}}}", $"${track.Price.ToString(CultureInfo.InvariantCulture):f2}" },
                {WebUtility.UrlDecode(@"\{\{\{back-to-album}}}"), backToAlbumPath },
                {@"{{{create-path}}}", WebUtility.UrlDecode($"/Tracks/Create?albumId={albumId}")}
            };

            return this.View("track", HttpResponseStatusCode.Ok, trackDetailsParameters);
        }

        [HttpGetAttribute("/Tracks/Details")]
        public IHttpResponse TrackDetails()
        {

            string albumId = this.Request.QueryData["albumId"].ToString();
            string trackId = this.Request.QueryData["trackId"].ToString();

            string backtoAlbumPath = WebUtility.UrlDecode($"/Albums/Details?id={albumId}");

            Track track = this.Context
                .Tracks
                .First(tr => tr.Id == trackId);

            Dictionary<string, string> trackDetailsParameters = new Dictionary<string, string>()
            {
                {"{{{link}}}", track.Link },
                {"{{{name}}}", track.Name },
                {"{{{price}}}", $"${track.Price:f2}" },
                { WebUtility.UrlDecode(@"\{\{\{back-to-album}}}"), backtoAlbumPath}
            };

            return this.View("track", HttpResponseStatusCode.Ok, trackDetailsParameters);
        }
    }
}