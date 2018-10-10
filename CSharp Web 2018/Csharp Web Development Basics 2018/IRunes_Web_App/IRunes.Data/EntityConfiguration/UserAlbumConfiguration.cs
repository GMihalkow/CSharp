namespace IRunes.Data.EntityConfiguration
{
    using IRunes.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserAlbumConfiguration : IEntityTypeConfiguration<UserAlbum>
    {
        public void Configure(EntityTypeBuilder<UserAlbum> builder)
        {
            builder
                 .HasOne(userAlbum => userAlbum.Album)
                 .WithMany(album => album.Users)
                 .HasForeignKey(userAlbum => userAlbum.AlbumId);

            builder
                .HasOne(userAlbum => userAlbum.User)
                .WithMany(user => user.Albums)
                .HasForeignKey(userAlbum => userAlbum.UserId);

            builder
                .HasKey(userAlbum => new { userAlbum.UserId, userAlbum.AlbumId });
        }
    }
}