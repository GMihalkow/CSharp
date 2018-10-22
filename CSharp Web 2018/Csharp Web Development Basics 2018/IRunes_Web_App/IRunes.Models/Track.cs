namespace IRunes.Models
{
    using System.Collections;
    using System.Collections.Generic;

    public class Track : BaseEntity<string>
    {
        public Track()
        {
            Albums = new HashSet<AlbumTrack>();
        }

        public string Name { get; set; }

        public string Link { get; set; }

        public decimal Price { get; set; }

        public ICollection<AlbumTrack> Albums { get; set; }
    }
}