namespace IRunes.App.ViewModels.Albums
{
    using IRunes.Models;

    public class AlbumDetailsViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string Price { get; set; }

        public AlbumTrack[] Tracks { get; set; }

        public string CreateTrack { get; set; }
    }
}