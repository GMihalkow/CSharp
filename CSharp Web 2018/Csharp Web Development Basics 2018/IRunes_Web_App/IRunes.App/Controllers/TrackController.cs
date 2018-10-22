namespace IRunes.App.Controllers
{
    using System;
    using IRunes.Models;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Responses.Contracts;
    using SIS.MvcFramework;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Text.RegularExpressions;
    using SIS.MvcFramework.Extenstions;
    using IRunes.App.ViewModels.Tracks;
    using IRunes.App.ViewModels.AlbumTracks;

    public class TrackController : BaseController
    {
        private const string InvalidTrackInformationError = @"<center><div class=\""alert alert-danger\"" role=\""alert\"">Invalid name/url/price information!</div></center>";

        private const string TrackAlreadyExistsError = @"<center><div class=\""alert alert-danger\"" role=\""alert\"">This track already exists!</div></center>";

        [HttpGetAttribute("/Tracks/Create")]
        public IHttpResponse CreateTrack()
        {
            string albumId = this.Request.QueryData["albumId"].ToString();

            string path = StringExtensions.UrlDecode($"'/Albums/Details?id={albumId}'");
            string postPath = StringExtensions.UrlDecode($"/Tracks/Create?albumId={albumId}");

            CreateTrackViewModel viewModel = new CreateTrackViewModel()
            {
                BackToAlbum = path,
                CreatePath = postPath,
                ErrorMessage = string.Empty
            };

            return this.View("createTrack", HttpResponseStatusCode.Ok, viewModel);
        }

        [HttpPostAttribute("/Tracks/Create")]
        public IHttpResponse PostCreateTrack(DoTrackViewModel model)
        {
            Regex trackNameRegex = new Regex(@"^\w{3,30}$");
            Regex linkUrlRegex = new Regex(@"^\b((http|https):\/\/?)[^\s()<>]+(?:\([\w\d]+\)|([^[:punct:]\s]|\/?))$");

            string albumId = this.Request.QueryData["albumId"].ToString();

            string backToAlbumPath = StringExtensions.UrlDecode($"'/Albums/Details?id={albumId}'");

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
                CreateTrackViewModel createTrackViewModel = new CreateTrackViewModel()
                {
                    BackToAlbum = backToAlbumPath,
                    ErrorMessage = InvalidTrackInformationError,
                    CreatePath = WebUtility.UrlDecode($"/Tracks/Create?albumId={albumId}")
                };

                return this.View("createTrack", HttpResponseStatusCode.BadRequest, createTrackViewModel);

            }
            else if (this.Context.AlbumTracks.Where(at => at.AlbumId == albumId).Any(tr => tr.Track.Name == model.Name))
            {
                CreateTrackViewModel createTrackViewModel = new CreateTrackViewModel()
                {
                    BackToAlbum = backToAlbumPath,
                    ErrorMessage = TrackAlreadyExistsError,
                    CreatePath = WebUtility.UrlDecode($"/Tracks/Create?albumId={albumId}")
                };

                return this.View("createTrack", HttpResponseStatusCode.BadRequest, createTrackViewModel);
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
            
            TrackViewModel viewModel = new TrackViewModel()
            {
                Link = track.Link,
                Name = track.Name,
                Price = $"{track.Price.ToString(CultureInfo.InvariantCulture):f2}",
                BackToAlbum = backToAlbumPath,
                CreatePath = StringExtensions.UrlDecode($"/Tracks/Create?albumId={albumId}")
            };
            
            return this.View("track", HttpResponseStatusCode.Ok, viewModel);
        }

        [HttpGetAttribute("/Tracks/Details")]
        public IHttpResponse TrackDetails(AlbumTrackViewModel model)
        {
            string backtoAlbumPath = StringExtensions.UrlDecode($"'/Albums/Details?id={model.AlbumId}'");

            Track track = this.Context
                .Tracks
                .First(tr => tr.Id == model.TrackId);

            var viewModel = track.To<TrackViewModel>();
            viewModel.BackToAlbum = backtoAlbumPath;

            return this.View("track", HttpResponseStatusCode.Ok, viewModel);
        }
    }
}