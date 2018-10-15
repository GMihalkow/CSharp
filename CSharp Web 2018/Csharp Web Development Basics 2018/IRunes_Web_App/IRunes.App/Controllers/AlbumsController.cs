namespace IRunes.App.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Text.RegularExpressions;
    using IRunes.App.ViewModels.Albums;
    using IRunes.Models;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Responses.Contracts;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Contracts.Services;
    using SIS.MvcFramework.Extenstions;

    public class AlbumsController : BaseController
    {
        private const string InvalidAlbumInformationError = "<center><div class=\"alert alert-danger\" role=\"alert\">Invalid cover link/album name!</div></center>";

        private const string AlbumAlreadyExistsError = "<center><div class=\"alert alert-danger\" role=\"alert\">Album already exists!</div></center>";


        [HttpGetAttribute("/Albums/Create")]
        public IHttpResponse GetCreatePage()
        {
            Dictionary<string, string> createAlbumPageParameters = new Dictionary<string, string>()
            {
                {"{{{error}}}", string.Empty }
            };

            return this.View("Albums-Create", HttpResponseStatusCode.Ok, createAlbumPageParameters);
        }

        [HttpPostAttribute("/Albums/Create")]
        public IHttpResponse PostCreateAlbum(DoAlbumInputModel model)
        {
            Regex albumNameRegex = new Regex(@"^\w{3,30}$");
            Regex coverUrlRegex = new Regex(@"^\b((http|https):\/\/?)[^\s()<>]+(?:\([\w\d]+\)|([^[:punct:]\s]|\/?))$");

            string cookieValue = this.Request.Cookies.GetCookie(AuthenticationCookieKey).Value;
            string username = this.UserCookieService.DecryptString(cookieValue, EncryptKey);

            string userId = this.Context
                            .Users
                            .First(user => user.Username == username)
                            .Id;

            string albumId = Guid.NewGuid().ToString();

            model.Cover = StringExtensions.UrlDecode(model.Cover);

            Album album = new Album()
            {
                Id = albumId,
                Name = model.Name,
                Cover = model.Cover
            };

            UserAlbum userAlbum = new UserAlbum()
            {
                Id = Guid.NewGuid().ToString(),
                UserId = userId,
                AlbumId = albumId
            };

            if (!albumNameRegex.Match(model.Name).Success || !coverUrlRegex.Match(model.Cover).Success)
            {
                Dictionary<string, string> createAlbumErrorParameters = new Dictionary<string, string>()
                {
                    {"{{{error}}}", InvalidAlbumInformationError }
                };

                return this.View("Albums-Create", HttpResponseStatusCode.BadRequest, createAlbumErrorParameters);
            }
            else if (this.Context.UserAlbums.Where(ua => ua.UserId == userId).Any(a => a.Album.Name == model.Name))
            {
                Dictionary<string, string> createAlbumErrorParameters = new Dictionary<string, string>()
                {
                    {"{{{error}}}", AlbumAlreadyExistsError}
                };

                return this.View("Albums-Create", HttpResponseStatusCode.BadRequest, createAlbumErrorParameters);
            }

            using (this.Context)
            {
                this.Context
                    .Add(album);

                this.Context
                    .UserAlbums
                    .Add(userAlbum);

                this.Context.SaveChanges();
            }

            Dictionary<string, string> createdAlbumParameters = new Dictionary<string, string>()
            {
                { "{{{url}}}", model.Cover },
                { @"\{\{\{create-track}}}", albumId },
                {"{{{name}}}", model.Name},
                {"{{{price}}}", album.Price.ToString(CultureInfo.InvariantCulture) },
                {"{{{tracks}}}", string.Empty }
            };

            return this.View("album", HttpResponseStatusCode.Ok, createdAlbumParameters);
        }

        [HttpGetAttribute("/Albums/All")]
        public IHttpResponse GetAllALbums()
        {
            StringBuilder sb = new StringBuilder();

            var cookie = this.Request.Cookies.GetCookie(AuthenticationCookieKey);
            string username = this.UserCookieService.DecryptString(cookie.Value, EncryptKey);
            string email = this.Context.Users.Where(ua => ua.Username == username).First().Email;

            var albums =
                this.Context
                .UserAlbums
                .Where(ua => ua.User.Username == username || ua.User.Email == email)
                .Select(ua => new
                {
                    ua.Album.Name,
                    ua.Album.Id
                })
                .ToArray();

            foreach (var album in albums)
            {
                sb.AppendLine($"<a href=\"/Albums/Details?id={album.Id}\">{album.Name}</a><br />");
            }

            Dictionary<string, string> allAlbumsParameters = new Dictionary<string, string>()
            {
                {"{{{albums}}}", string.Join("<br />", sb) }
            };

            return this.View("all-albums", HttpResponseStatusCode.Ok, allAlbumsParameters);
        }

        [HttpGetAttribute("/Albums/Details")]
        public IHttpResponse GetAlbum(AlbumDetailsViewModel model)
        {
            StringBuilder sb = new StringBuilder();

            Album album =
                this.Context
                .Albums
                .First(a => a.Id == model.Id);

            decimal albumPrice =
                this.Context
                .AlbumTracks
                .Where(at => at.AlbumId == model.Id)
                .Sum(track => track.Track.Price)
                * 0.87m;

            var tracks =
                this.Context
                .AlbumTracks
                .Where(at => at.AlbumId == model.Id)
                .Select(at => new
                {
                    at.Track.Name,
                    at.TrackId
                })
                .ToArray();

            sb.AppendLine("<ul>");
            foreach (var track in tracks)
            {
                sb.AppendLine($"<li><a href=\"/Tracks/Details?albumId={model.Id}&trackId={track.TrackId}\">{track.Name}</a></li>");
            }
            sb.AppendLine("</ul>");

            Dictionary<string, string> albumsDetailsParameters = new Dictionary<string, string>()
            {
                {"{{{url}}}", album.Cover },
                {"{{{name}}}", album.Name },
                {"{{{price}}}", $"{albumPrice:f2}"},
                {@"\{\{\{create-track}}}", $"{album.Id}" },
                {"{{{tracks}}}", sb.ToString().TrimEnd() }
            };

            return this.View("album", HttpResponseStatusCode.Ok, albumsDetailsParameters);
        }
    }
}