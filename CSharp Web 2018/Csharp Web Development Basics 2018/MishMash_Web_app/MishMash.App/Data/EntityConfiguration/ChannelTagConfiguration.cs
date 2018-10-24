namespace MishMash.App.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MishMash.App.Models;

    public class ChannelTagConfiguration : IEntityTypeConfiguration<ChannelTag>
    {
        public void Configure(EntityTypeBuilder<ChannelTag> builder)
        {
            builder
                .HasOne(ct => ct.Channel)
                .WithMany(ch => ch.Tags)
                .HasForeignKey(ct => ct.ChannelId);

            builder
                .HasOne(ct => ct.Tag)
                .WithMany(t => t.Channels)
                .HasForeignKey(ct => ct.TagId);

            builder.HasKey(ct => new { ct.TagId, ct.ChannelId });
        }
    }
}