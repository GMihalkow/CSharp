namespace ByTheCake.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ByTheCake.Models;

    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Name)
                .IsRequired(true)
                .HasAnnotation(@"[StringLength(30, MinimumLength = 3, ErrorMessage = ""Invalid"")]", true)
                .HasColumnType("VARCHAR(30)");

            builder
                .Property(p => p.ImageUrl)
                .IsRequired(false);
        }
    }
}
