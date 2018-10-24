namespace MishMash.App.Data
{
    using JetBrains.Annotations;
    using Microsoft.EntityFrameworkCore;
    using MishMash.App.Data.EntityConfiguration;
    using MishMash.App.Models;

    public class MishMashDbContext : DbContext
    {
        public MishMashDbContext()
        {
        }

        public MishMashDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Channel> Channels { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<ChannelTag> ChannelTags { get; set; }

        public DbSet<UserChannel> UserChannels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=MishMashDb;Trusted_Connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<User>(new UserConfiguration());

            modelBuilder.ApplyConfiguration<UserChannel>(new UserChannelConfiguration());

            modelBuilder.ApplyConfiguration<ChannelTag>(new ChannelTagConfiguration());
        }
    }
}