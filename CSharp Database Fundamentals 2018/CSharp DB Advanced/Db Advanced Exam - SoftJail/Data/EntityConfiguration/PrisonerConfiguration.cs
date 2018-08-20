using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftJail.Data.Models;

namespace SoftJail.Data
{
    public class PrisonerConfiguration : IEntityTypeConfiguration<Prisoner>
    {
        public void Configure(EntityTypeBuilder<Prisoner> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.FullName)
                .HasColumnType("VARCHAR(20)")
                .HasAnnotation(@"[StringLength(20, MinimumLength = 3, ErrorMessage = ""Invalid"")]", true)
                .IsRequired(true);

            builder
                .Property(p => p.Nickname)
                .HasColumnType("VARCHAR(MAX)")
                .IsRequired(true);

            builder
                .Property(p => p.Age)
                .HasColumnType("INT")
                .HasAnnotation("Range(18, 65)", true)
                .IsRequired(true);

            builder
                .Property(p => p.IncarcerationDate)
                .IsRequired(true);

            builder
                .Property(p => p.Bail)
                .HasColumnType("DECIMAL")
                .HasAnnotation("Range(0, decimal.MaxValue", true)
                .IsRequired(false);

            builder
                .HasOne(p => p.Cell)
                .WithMany(c => c.Prisoners)
                .HasForeignKey(p => p.CellId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}