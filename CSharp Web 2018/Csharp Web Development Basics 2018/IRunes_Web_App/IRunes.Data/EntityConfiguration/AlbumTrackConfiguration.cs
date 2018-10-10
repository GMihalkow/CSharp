namespace IRunes.Data.EntityConfiguration
{
    using IRunes.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AlbumTrackConfiguration : IEntityTypeConfiguration<AlbumTrack>
    {
        public void Configure(EntityTypeBuilder<AlbumTrack> builder)
        {
            builder
                .HasOne(at => at.Album)
                .WithMany(a => a.Tracks)
                .HasForeignKey(at => at.AlbumId);

            builder
                .HasOne(at => at.Track)
                .WithMany(t => t.Albums)
                .HasForeignKey(at => at.TrackId);

            builder
                .HasKey(at => new { at.TrackId, at.AlbumId });
        }
    }
}