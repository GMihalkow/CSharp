using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftJail.Data.Models;

namespace SoftJail.Data
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder
                .HasKey(dp => dp.Id);

            builder
                .Property(dp => dp.Name)
                .HasColumnType("VARCHAR(25)")
                .HasAnnotation(@"[StringLength(25, MinimumLength = 3, ErrorMessage = ""Invalid"")]", true)
                .IsRequired(true);
        }
    }
}