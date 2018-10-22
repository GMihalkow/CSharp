namespace IRunes.Data.EntityConfiguration
{
    using IRunes.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TrackConfiguration : IEntityTypeConfiguration<Track>
    {
        public void Configure(EntityTypeBuilder<Track> builder)
        {
            builder
                .HasKey(track => track.Id);

            builder
                .Property(track => track.Name)
                .HasAnnotation(@"[StringLength(30, MinimumLength = 3, ErrorMessage = ""Invalid"")]", true)
                .HasColumnType("VARCHAR(30)");

            builder
                .Property(track => track.Link)
                .HasColumnType("VARCHAR(MAX)");
        }
    }
}