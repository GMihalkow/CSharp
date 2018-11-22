namespace Eventures.Web.Data
{
    using Eventures.Data.EntityConfiguration;
    using Eventures.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class EventuresDbContext : IdentityDbContext<EventureUser>
    {
        public EventuresDbContext(DbContextOptions options) : base(options)
        {
        }

        public EventuresDbContext()
        {
        }

        public DbSet<Event> Events { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder
                .ApplyConfiguration(new OrderConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=EventuresDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}