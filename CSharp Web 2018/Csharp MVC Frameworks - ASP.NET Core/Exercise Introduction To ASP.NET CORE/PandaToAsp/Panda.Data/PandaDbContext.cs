namespace PandaToAsp.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Panda.Models;

    public class PandaDbContext : IdentityDbContext<PandaUser>
    {
        public PandaDbContext(DbContextOptions<PandaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Package> Packages { get; set; }

        public DbSet<Receipt> Receipts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=PandaDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Receipt>(r => r.HasKey(x => x.Id));

            builder.Entity<Receipt>(r => r
            .HasOne(x => x.Package)
            .WithMany(p => p.Receipts)
            .HasForeignKey(x => x.PackageId));

            builder.Entity<Receipt>(r => r
            .HasOne(x => x.Recipient)
            .WithMany(u => u.Receipts)
            .HasForeignKey(x => x.RecipientId));
        }
    }
}
