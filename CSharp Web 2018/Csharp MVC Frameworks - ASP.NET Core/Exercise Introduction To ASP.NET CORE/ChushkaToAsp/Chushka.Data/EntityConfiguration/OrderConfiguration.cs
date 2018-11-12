namespace Chushka.Data.EntityConfiguration
{
    using Chushka.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasKey(o => o.Id);

            builder
                .HasOne(o => o.Client)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.ClientId);

            builder
                .HasOne(o => o.Product)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.ProductId);
        }
    }
}
