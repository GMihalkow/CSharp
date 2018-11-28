namespace Eventures.Data.EntityConfiguration
{
    using Eventures.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasKey(o => o.Id);

            builder
                .HasOne(o => o.Event)
                .WithMany(e => e.Orders)
                .HasForeignKey(o => o.EventId);

            builder
                .HasOne(o => o.Customer)
                .WithMany(e => e.Orders)
                .HasForeignKey(o => o.CustomerId);
        }
    }
}