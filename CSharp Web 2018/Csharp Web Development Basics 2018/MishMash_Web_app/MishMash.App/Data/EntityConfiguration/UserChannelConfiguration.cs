namespace MishMash.App.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MishMash.App.Models;

    public class UserChannelConfiguration : IEntityTypeConfiguration<UserChannel>
    {
        public void Configure(EntityTypeBuilder<UserChannel> builder)
        {
            builder
                .HasOne(uc => uc.Channel)
                .WithMany(ch => ch.Followers)
                .HasForeignKey(uc => uc.ChannelId);

            builder
                .HasOne(uc => uc.User)
                .WithMany(u => u.Channels)
                .HasForeignKey(uc => uc.UserId);

            builder.HasKey(uc => new { uc.UserId, uc.ChannelId });
        }
    }
}