using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftJail.Data.Models;

namespace SoftJail.Data
{
    public class MailConfiguration : IEntityTypeConfiguration<Mail>
    {
        public void Configure(EntityTypeBuilder<Mail> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Description)
                .HasColumnType("VARCHAR(MAX)")
                .IsRequired(true);

            builder
                .Property(m => m.Sender)
                .HasColumnType("VARCHAR(MAX)")
                .IsRequired(true);

            builder
                .Property(m => m.Address)
                .HasColumnType("VARCHAR(MAX)")
                .IsRequired(true);

            builder
                .HasOne(m => m.Prisoner)
                .WithMany(p => p.Mails)
                .HasForeignKey(m => m.PrisonerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}