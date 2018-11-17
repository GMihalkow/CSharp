﻿namespace Eventures.Web.Data
{
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=EventuresDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}