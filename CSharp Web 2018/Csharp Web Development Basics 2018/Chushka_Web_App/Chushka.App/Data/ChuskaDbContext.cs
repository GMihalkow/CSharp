namespace Chushka.App.Data
{
    using Chushka.App.Data.EntityConfiguration;
    using Chushka.App.Models;
    using Microsoft.EntityFrameworkCore;

    public class ChuskaDbContext : DbContext
    {
        public ChuskaDbContext()
        {
        }

        public ChuskaDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=ChushkaDb;Trusted_Connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Order>(new OrderConfiguration());
        }
    }
}