namespace IRunes.App.Controllers
{
    using System;
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
    using SIS.WebServer.Results;

    public class AlbumsController : BaseController
    {
        private const string InvalidAlbumInformationError = "<p style=\"text-align:center;\">Invalid cover link/album name!</p>";
        private const string AlbumAlreadyExistsError = "<p style=\"text-align:center;\">Album already exists!</p>";

        public IHttpResponse GetCreatePage(IHttpRequest request)
        {
            string registerView = new CreateAlbumView().View();
            registerView = registerView.Replace("{{{error}}}", string.Empty);

            var response = new HtmlResult(registerView, HttpResponseStatusCode.Ok);

            return response;
        }

        public IHttpResponse PostCreateAlbum(IHttpRequest request)
        {
            Regex albumNameRegex = new Regex(@"^\w{3,30}$");
            Regex coverUrlRegex = new Regex(@"^\b((http|https):\/\/?)[^\s()<>]+(?:\([\w\d]+\)|([^[:punct:]\s]|\/?))$");

            string username = EncryptService.Decrypt(request.Cookies.GetCookie(AuthenticationCookieKey).Value, EncryptKey);

            string userId = this.Context
                            .Users
                            .First(user => user.Username == username)
                            .Id;

            string albumId = Guid.NewGuid().ToString();
            string albumName = request.FormData["name"].ToString();
            string cover = request.FormData["cover"].ToString();
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
                string createAlbumView = new CreateAlbumView().View();
                createAlbumView = createAlbumView.Replace("{{{error}}}", InvalidAlbumInformationError);

                return new HtmlResult(createAlbumView, HttpResponseStatusCode.BadRequest);
            }
            else if (this.Context.UserAlbums.Where(ua => ua.UserId == userId).Any(a => a.Album.Name == albumName))
            {
                string createAlbumView = new CreateAlbumView().View();
                createAlbumView = createAlbumView.Replace("{{{error}}}", AlbumAlreadyExistsError);

                return new HtmlResult(createAlbumView, HttpResponseStatusCode.BadRequest);
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

            string view = new AlbumDetailsView().View();
            view = view.Replace("{{{url}}}", cover);
            view = view.Replace(@"\{\{\{create-track}}}", albumId);
            view = view.Replace("{{{name}}}", albumName);
            view = view.Replace("{{{price}}}", album.Price.ToString(CultureInfo.InvariantCulture));
            view = view.Replace("{{{tracks}}}", string.Empty);

            return new HtmlResult(view, HttpResponseStatusCode.Ok);
        }

        public IHttpResponse GetAllALbums(IHttpRequest request)
        {
            StringBuilder sb = new StringBuilder();

            var cookie = request.Cookies.GetCookie(AuthenticationCookieKey);
            string username = EncryptService.Decrypt(cookie.Value, EncryptKey);

            var albums =
                this.Context
                .UserAlbums
                .Where(ua => ua.User.Username == username)
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

            string view = new AlbumsView().View();
            view = view.Replace("{{{albums}}}", string.Join("<br />", sb));

            var response = new HtmlResult(view, HttpResponseStatusCode.Ok);

            return response;
        }

        public IHttpResponse GetAlbum(IHttpRequest request)
        {
            StringBuilder sb = new StringBuilder();

            string albumId = request.QueryData["id"].ToString();

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

            ;

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

            var view = new AlbumDetailsView().View();
            view = view.Replace("{{{url}}}", album.Cover);
            view = view.Replace("{{{name}}}", album.Name);
            view = view.Replace("{{{price}}}", $"${albumPrice:f2}");
            view = view.Replace(@"\{\{\{create-track}}}", $"{album.Id}");
            view = view.Replace("{{{tracks}}}", sb.ToString().TrimEnd());

            var response = new HtmlResult(view, HttpResponseStatusCode.Ok);

            return response;
        }
    }
}