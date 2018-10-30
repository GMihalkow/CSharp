namespace Judge.App.Data.EntityConfiguration
{
    using Judge.App.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ContestConfiguration : IEntityTypeConfiguration<Contest>
    {
        public void Configure(EntityTypeBuilder<Contest> builder)
        {
            builder
                .HasMany(c => c.Submissions)
                .WithOne(s => s.Contest)
                .HasForeignKey(s => s.ContestId);
        }
    }
}