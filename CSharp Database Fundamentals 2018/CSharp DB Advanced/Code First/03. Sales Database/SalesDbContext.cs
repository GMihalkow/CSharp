using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_SalesDatabase.Data
{
    public class SalesDbContext : DbContext
    {
        public SalesDbContext()
        {

        }

        public SalesDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasMany(s => s.Sales)
                .WithOne(p => p.Product)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Customer>()
                .HasMany(s => s.Sales)
                .WithOne(c => c.Customer)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Store>()
                 .HasMany(s => s.Sales)
                 .WithOne(st => st.Store)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Sale>()
                .HasKey(s => s.SaleId);
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
