namespace IRunes.App.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using IRunes.App.ViewModels.Albums;
    using IRunes.Models;
    using Microsoft.EntityFrameworkCore;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Responses.Contracts;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Extenstions;

    public class AlbumsController : BaseController
    {
        private const string InvalidAlbumInformationError = @"<center><div class=\""alert alert-danger\"" role=\""alert\"">Invalid cover link/album name!</div></center>";

        private const string AlbumAlreadyExistsError = @"<center><div class=\""alert alert-danger\"" role=\""alert\"">Album already exists!</div></center>";


        [HttpGetAttribute("/Albums/Create")]
        public IHttpResponse GetCreatePage()
        {
            GetCreateAlbumPageViewModel viewModel = new GetCreateAlbumPageViewModel()
            {
                ErrorMessage = string.Empty
            };

            return this.View("AlbumsCreate", HttpResponseStatusCode.Ok, viewModel);
        }

        [HttpPostAttribute("/Albums/Create")]
        public IHttpResponse PostCreateAlbum(DoAlbumInputViewModel model)
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
                GetCreateAlbumPageViewModel createPageViewModel = new GetCreateAlbumPageViewModel()
                {
                    ErrorMessage = InvalidAlbumInformationError
                };

                return this.View("AlbumsCreate", HttpResponseStatusCode.BadRequest, createPageViewModel);
            }
            else if (this.Context.UserAlbums.Where(ua => ua.UserId == userId).Any(a => a.Album.Name == model.Name))
            {
                GetCreateAlbumPageViewModel createPageViewModel = new GetCreateAlbumPageViewModel()
                {
                    ErrorMessage = AlbumAlreadyExistsError
                };

                return this.View("AlbumsCreate", HttpResponseStatusCode.BadRequest, createPageViewModel);
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

            AlbumDetailsViewModel viewModel = new AlbumDetailsViewModel()
            {
                Name = model.Name,
                Price = $"{album.Price.ToString(CultureInfo.InvariantCulture):F2}",
                Tracks = new AlbumTrack[0],
                Url = model.Cover,
                CreateTrack = $"'/Tracks/Create?albumId={album.Id}'"
            };
            
            return this.View("album", HttpResponseStatusCode.Ok, viewModel);
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
                .Include(x => x.Album)
                .Where(ua => ua.User.Username == username || ua.User.Email == email)
                .ToArray();

            GetAlbumsPageViewModel viewModel = new GetAlbumsPageViewModel()
            {
                AllAlbums = albums
            };

            return this.View("allAlbums", HttpResponseStatusCode.Ok, albums);
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
                .Include(x => x.Track)
                .Include(x => x.Album)
                .Where(at => at.AlbumId == model.Id)
                .ToArray();

            AlbumDetailsViewModel viewModel = new AlbumDetailsViewModel();

            viewModel.Name = album.Name;
            viewModel.Url = album.Cover;
            viewModel.Price = $"{album.Price:F2}";
            viewModel.Tracks = tracks;
            viewModel.CreateTrack = $"'/Tracks/Create?albumId={album.Id}'";

            return this.View("album", HttpResponseStatusCode.Ok, viewModel);
        }
    }
}