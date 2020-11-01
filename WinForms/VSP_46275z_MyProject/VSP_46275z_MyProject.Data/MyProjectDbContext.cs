using Microsoft.EntityFrameworkCore;
using VSP_46275z_MyProject.Data.EntityConfiguration;
using VSP_46275z_MyProject.Models;

namespace VSP_46275z_MyProject.Data.Data
{
    public class MyProjectDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TestAppDb;Integrated Security=True;");
    }
}