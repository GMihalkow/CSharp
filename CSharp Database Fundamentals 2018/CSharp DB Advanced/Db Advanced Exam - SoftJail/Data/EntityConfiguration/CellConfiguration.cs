using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftJail.Data.Models;

namespace SoftJail.Data
{
    public class CellConfiguration : IEntityTypeConfiguration<Cell>
    {
        public void Configure(EntityTypeBuilder<Cell> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.CellNumber)
                .HasColumnType("INT")
                .HasAnnotation("Raneg(1, 1000)", true)
                .IsRequired(true);

            builder
                .Property(c => c.HasWindow)
                .IsRequired(true);

            builder
                .HasOne(c => c.Department)
                .WithMany(d => d.Cells)
                .HasForeignKey(c => c.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}