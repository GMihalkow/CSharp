using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftJail.Data.Models;

namespace SoftJail.Data
{
    public class OfficerConfiguration : IEntityTypeConfiguration<Officer>
    {
        public void Configure(EntityTypeBuilder<Officer> builder)
        {
            builder
                .HasKey(of => of.Id);

            builder
                .Property(of => of.FullName)
                .HasColumnType("VARCHAR(30)")
                .HasAnnotation(@"[StringLength(30, MinimumLength = 3, ErrorMessage = ""Invalid"")]", true)
                .IsRequired(true);

            builder
                .Property(of => of.Salary)
                .HasColumnType("DECIMAL")
                .HasAnnotation("Range(0.00, decimal.MaxValue", true)
                .IsRequired(true);

            builder
                .Property(of => of.Position)
                .IsRequired(true);

            builder
                .Property(of => of.Weapon)
                .IsRequired(true);

            builder
                .Property(of => of.DepartmentId)
                .HasAnnotation(@"Key,ForeignKey(""Department""),Column(""DepartentId"")", true);
            //look up DepartmentId


        }
    }
}