namespace Judge.App.Data.EntityConfiguration
{
    using Judge.App.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasMany(u => u.Submissions)
                .WithOne(s => s.User)
                .HasForeignKey(s => s.UserId);
        }
    }
}
