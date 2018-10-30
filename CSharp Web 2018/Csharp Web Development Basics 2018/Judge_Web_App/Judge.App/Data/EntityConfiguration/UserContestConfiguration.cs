namespace Judge.App.Data.EntityConfiguration
{
    using Judge.App.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserContestConfiguration : IEntityTypeConfiguration<UserContest>
    {
        public void Configure(EntityTypeBuilder<UserContest> builder)
        {
            builder
                .HasOne(uc => uc.User)
                .WithMany(u => u.Contests)
                .HasForeignKey(uc => uc.UserId);

            builder
                .HasOne(uc => uc.Contest)
                .WithMany(c => c.Users)
                .HasForeignKey(uc => uc.ContestId);

            builder.HasKey(uc => new { uc.ContestId, uc.UserId });
        }
    }
}