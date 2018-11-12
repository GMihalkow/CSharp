namespace Chushka.Web.Data
{
    using Chushka.Data.EntityConfiguration;
    using Chushka.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ChushkaDbContext : IdentityDbContext<ChushkaUser>
    {
        public ChushkaDbContext(DbContextOptions<ChushkaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=ChushkaDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration<Order>(new OrderConfiguration());
        }
    }
}