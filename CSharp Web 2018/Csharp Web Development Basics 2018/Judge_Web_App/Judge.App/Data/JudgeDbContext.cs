namespace Judge.App.Data
{
    using Judge.App.Data.EntityConfiguration;
    using Judge.App.Models;
    using Microsoft.EntityFrameworkCore;

    public class JudgeDbContext : DbContext
    {
        public JudgeDbContext()
        {

        }

        public JudgeDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Contest> Contests { get; set; }

        public DbSet<Submission> Submissions { get; set; }

        public DbSet<UserContest> UserContests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=JudgeDb;Trusted_Connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<UserContest>(new UserContestConfiguration());

            modelBuilder.ApplyConfiguration<User>(new UserConfiguration());

            modelBuilder.ApplyConfiguration<Contest>(new ContestConfiguration());
        }
    }
}
