namespace IRunes.App.ViewModels.Albums
{
    using IRunes.Models;
    using System.Collections.Generic;

    public class AlbumDetailsViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Cover { get; set; }

        public string Price { get; set; }

        public ICollection<AlbumTrack> Tracks { get; set; }

        public string CreateTrack { get; set; }
    }
}