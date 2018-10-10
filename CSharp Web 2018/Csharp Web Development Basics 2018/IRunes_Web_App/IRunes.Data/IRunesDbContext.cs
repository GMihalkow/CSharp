namespace IRunes.Data
{
    using IRunes.Data.EntityConfiguration;
    using IRunes.Models;
    using JetBrains.Annotations;
    using Microsoft.EntityFrameworkCore;

    public class IRunesDbContext : DbContext
    {
        public IRunesDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public IRunesDbContext()
        {
        }

        public DbSet<UserAlbum> UserAlbums { get; set; }

        public DbSet<User> Users { get; set; }
        
        public DbSet<Track> Tracks { get; set; }
            
        public DbSet<Album> Albums { get; set; }

        public DbSet<AlbumTrack> AlbumTracks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration<User>(new UserConfiguration());

            builder.ApplyConfiguration<Album>(new AlbumConfiguration());

            builder.ApplyConfiguration<Track>(new TrackConfiguration());

            builder.ApplyConfiguration<AlbumTrack>(new AlbumTrackConfiguration());
        }
    }
}