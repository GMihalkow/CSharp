namespace IRunes.App.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Text.RegularExpressions;
    using IRunes.App.Views;
    using IRunes.Models;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses;
    using SIS.HTTP.Responses.Contracts;
    using SIS.MvcFramework;
    using SIS.WebServer.Results;

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

            return this.View("Albums-Create",  HttpResponseStatusCode.Ok, createAlbumPageParameters);
        }

        [HttpPostAttribute("/Albums/Create")]
        public IHttpResponse PostCreateAlbum()
        {
            Regex albumNameRegex = new Regex(@"^\w{3,30}$");
            Regex coverUrlRegex = new Regex(@"^\b((http|https):\/\/?)[^\s()<>]+(?:\([\w\d]+\)|([^[:punct:]\s]|\/?))$");

            string cookieValue = this.Request.Cookies.GetCookie(AuthenticationCookieKey).Value;
            string username = SIS.MvcFramework.Services.UserCookieService.DecryptString(cookieValue, SIS.MvcFramework.Services.UserCookieService.EncryptKey);

            string userId = this.Context
                            .Users
                            .First(user => user.Username == username)
                            .Id;

            string albumId = Guid.NewGuid().ToString();
            string albumName = this.Request.FormData["name"].ToString();
            string cover = this.Request.FormData["cover"].ToString();
            cover = WebUtility.UrlDecode(cover);

            Album album = new Album()
            {
                Id = albumId,
                Name = albumName,
                Cover = cover
            };

            UserAlbum userAlbum = new UserAlbum()
            {
                Id = Guid.NewGuid().ToString(),
                UserId = userId,
                AlbumId = albumId
            };

            if (!albumNameRegex.Match(albumName).Success || !coverUrlRegex.Match(cover).Success)
            {
                Dictionary<string, string> createAlbumErrorParameters = new Dictionary<string, string>()
                {
                    {"{{{error}}}", InvalidAlbumInformationError }
                };

                return this.View("Albums-Create", HttpResponseStatusCode.BadRequest, createAlbumErrorParameters);
            }
            else if (this.Context.UserAlbums.Where(ua => ua.UserId == userId).Any(a => a.Album.Name == albumName))
            {
                Dictionary<string, string> createAlbumErrorParameters = new Dictionary<string, string>()
                {
                    {"{{{error}}}", AlbumAlreadyExistsError}
                };

                return this.View("Albums-Create",  HttpResponseStatusCode.BadRequest, createAlbumErrorParameters);
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
                { "{{{url}}}", cover },
                { @"\{\{\{create-track}}}", albumId },
                {"{{{name}}}", albumName },
                {"{{{price}}}", album.Price.ToString(CultureInfo.InvariantCulture) },
                {"{{{tracks}}}", string.Empty }
            };

            return this.View("album",  HttpResponseStatusCode.Ok, createdAlbumParameters);
        }

        [HttpGetAttribute("/Albums/All")]
        public IHttpResponse GetAllALbums()
        {
            StringBuilder sb = new StringBuilder();

            var cookie = this.Request.Cookies.GetCookie(AuthenticationCookieKey);
            string username = SIS.MvcFramework.Services.UserCookieService.DecryptString(cookie.Value, SIS.MvcFramework.Services.UserCookieService.EncryptKey);
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

            return this.View("all-albums",  HttpResponseStatusCode.Ok, allAlbumsParameters);
        }

        [HttpGetAttribute("/Albums/Details")]
        public IHttpResponse GetAlbum()
        {
            StringBuilder sb = new StringBuilder();

            string albumId = this.Request.QueryData["id"].ToString();

            Album album =
                this.Context
                .Albums
                .First(a => a.Id == albumId);

            decimal albumPrice =
                this.Context
                .AlbumTracks
                .Where(at => at.AlbumId == albumId)
                .Sum(track => track.Track.Price)
                * 0.87m;

            var tracks =
                this.Context
                .AlbumTracks
                .Where(at => at.AlbumId == albumId)
                .Select(at => new
                {
                    at.Track.Name,
                    at.TrackId
                })
                .ToArray();

            sb.AppendLine("<ul>");
            foreach (var track in tracks)
            {
                sb.AppendLine($"<li><a href=\"/Tracks/Details?albumId={albumId}&trackId={track.TrackId}\">{track.Name}</a></li>");
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

            return this.View("album",  HttpResponseStatusCode.Ok, albumsDetailsParameters);
        }
    }
}