namespace IRunes.App.Controllers
{
    using System;
    using IRunes.Models;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Responses.Contracts;
    using SIS.MvcFramework;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Text.RegularExpressions;
    using SIS.MvcFramework.Extenstions;
    using IRunes.App.ViewModels.Tracks;
    using IRunes.App.ViewModels.AlbumTracks;

    public class TrackController : BaseController
    {
        private const string InvalidTrackInformationError = "<center><div class=\"alert alert-danger\" role=\"alert\">Invalid name/url/price information!</div></center>";

        private const string TrackAlreadyExistsError = "<center><div class=\"alert alert-danger\" role=\"alert\">This track already exists!</div></center>";

        [HttpGetAttribute("/Tracks/Create")]
        public IHttpResponse CreateTrack()
        {
            string albumId = this.Request.QueryData["albumId"].ToString();

            string path = StringExtensions.UrlDecode($"/Albums/Details?id={albumId}");
            string postPath = StringExtensions.UrlDecode($"/Tracks/Create?albumId={albumId}");

            Dictionary<string, string> createTrackParameters = new Dictionary<string, string>()
            {
                {WebUtility.UrlDecode(@"\{\{\{back-to-album}}}"), path},
                {"{{{create-path}}}", postPath },
                {"{{{error}}}", string.Empty }
            };

            return this.View("create-track", HttpResponseStatusCode.Ok, createTrackParameters);
        }

        [HttpPostAttribute("/Tracks/Create")]
        public IHttpResponse PostCreateTrack(DoTrackInputModel model)
        {
            Regex trackNameRegex = new Regex(@"^\w{3,30}$");
            Regex linkUrlRegex = new Regex(@"^\b((http|https):\/\/?)[^\s()<>]+(?:\([\w\d]+\)|([^[:punct:]\s]|\/?))$");

            string albumId = this.Request.QueryData["albumId"].ToString();

            string backToAlbumPath = StringExtensions.UrlDecode($"/Albums/Details?id={albumId}");

            model.Link = StringExtensions.UrlDecode(model.Link);
            decimal trackPrice = 0;

            bool IsDecimal = decimal.TryParse(model.Price.ToString(), out trackPrice);

            Track track = new Track()
            {
                Id = Guid.NewGuid().ToString(),
                Name = model.Name,
                Price = trackPrice,
                Link = model.Link
            };

            AlbumTrack albumTrack = new AlbumTrack()
            {
                AlbumId = albumId,
                TrackId = track.Id
            };

            if (!IsDecimal
                ||
                !linkUrlRegex.Match(model.Link).Success
                ||
                !trackNameRegex.Match(model.Name).Success
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
            else if (this.Context.AlbumTracks.Where(at => at.AlbumId == albumId).Any(tr => tr.Track.Name == model.Name))
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
                {@"{{{create-path}}}", StringExtensions.UrlDecode($"/Tracks/Create?albumId={albumId}")}
            };

            return this.View("track", HttpResponseStatusCode.Ok, trackDetailsParameters);
        }

        [HttpGetAttribute("/Tracks/Details")]
        public IHttpResponse TrackDetails(AlbumTrackViewModel model)
        {
            string backtoAlbumPath = StringExtensions.UrlDecode($"/Albums/Details?id={model.AlbumId}");

            Track track = this.Context
                .Tracks
                .First(tr => tr.Id == model.TrackId);

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