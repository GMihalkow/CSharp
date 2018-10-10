namespace IRunes.Models
{
    public class UserAlbum : BaseEntity<string>
    {
        public string UserId { get; set; }

        public User User { get; set; }

        public string AlbumId { get; set; }

        public Album Album { get; set; }
    }
}
