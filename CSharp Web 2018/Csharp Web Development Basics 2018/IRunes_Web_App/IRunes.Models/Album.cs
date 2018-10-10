namespace IRunes.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class Album : BaseEntity<string>
    {
        public Album()
        {
            this.Tracks = new HashSet<AlbumTrack>();
        }

        public string Name { get; set; }

        public string Cover { get; set; }

        public decimal Price =>
                this.Tracks.Sum(tr => tr.Track.Price)
                -
                (this.Tracks.Sum(tr => tr.Track.Price) * 0.13m);

        public ICollection<AlbumTrack> Tracks { get; set; }

        public ICollection<UserAlbum> Users { get; set; }
    }
}
