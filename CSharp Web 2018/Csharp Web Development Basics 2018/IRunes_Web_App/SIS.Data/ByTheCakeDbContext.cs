namespace ByTheCake.Data
{
    using JetBrains.Annotations;
    using Microsoft.EntityFrameworkCore;
    using ByTheCake.Data.EntityConfiguration;
    using ByTheCake.Models;

    public class ByTheCakeDbContext : DbContext
    {
        public ByTheCakeDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public ByTheCakeDbContext()
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<ProductOrder> ProductOrders { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration<Product>(new ProductConfiguration());

            builder
                .ApplyConfiguration<Order>(new OrderConfiguration());

            builder
                .ApplyConfiguration<ProductOrder>(new ProductOrderConfiguration());

            builder
                .ApplyConfiguration<User>(new UserConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }
    }
}
