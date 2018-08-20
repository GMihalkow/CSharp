using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftJail.Data.Models;

namespace SoftJail.Data
{
    public class OfficerPrisonerConfiguration : IEntityTypeConfiguration<OfficerPrisoner>
    {
        public void Configure(EntityTypeBuilder<OfficerPrisoner> builder)
        {
            builder
                .HasOne(op => op.Officer)
                .WithMany(o => o.OfficerPrisoners)
                .HasForeignKey(op => op.OfficerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(op => op.Prisoner)
                .WithMany(p => p.PrisonerOfficers)
                .HasForeignKey(op => op.PrisonerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasKey(op => new { op.PrisonerId, op.OfficerId });
        }
    }
}