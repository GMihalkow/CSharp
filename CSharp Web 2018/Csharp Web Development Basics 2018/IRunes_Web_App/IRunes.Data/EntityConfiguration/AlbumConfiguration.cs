namespace IRunes.Data.EntityConfiguration
{
    using IRunes.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder
                .HasKey(album => album.Id);

            builder
                .Property(album => album.Name)
                .HasAnnotation(@"[StringLength(30, MinimumLength = 3, ErrorMessage = ""Invalid"")]", true)
                .HasColumnType("VARCHAR(30)");

            builder
                .Property(album => album.Price)
                .HasColumnType("DECIMAL");

            builder
                .Ignore("Price");
        }
    }
}
