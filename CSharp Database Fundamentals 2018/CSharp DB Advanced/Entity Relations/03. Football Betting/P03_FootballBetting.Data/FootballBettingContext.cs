using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        protected FootballBettingContext()
        {
        }

        public FootballBettingContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Team
            modelBuilder.Entity<Team>(entity =>
            {
                //Id
                entity.HasKey(e => e.TeamId);

                //Colors
                entity.HasOne(e => e.PrimaryKitColor)
                .WithMany(c => c.PrimaryKitTeams)
                .HasForeignKey(e => e.PrimaryKitColorId);

                entity.HasOne(e => e.SecondaryKitColor)
                .WithMany(c => c.SecondaryKitTeams)
                .HasForeignKey(e => e.SecondaryKitColorId);

                //Town
                entity.HasOne(e => e.Town)
                .WithMany(t => t.Teams)
                .HasForeignKey(e => e.TownId);

            });

            //Game
            modelBuilder.Entity<Game>(entity =>
            {
                //Home games
                entity.HasOne(g => g.HomeTeam)
                .WithMany(t => t.HomeGames)
                .HasForeignKey(g => g.HomeTeamId);

                //Away games
                entity.HasOne(g => g.AwayTeam)
                .WithMany(t => t.AwayGames)
                .HasForeignKey(g => g.AwayTeamId);

            });

            //Town
            modelBuilder.Entity<Town>(entity =>
            {
                //Countries
                entity.HasOne(t => t.Country)
                .WithMany(c => c.Towns)
                .HasForeignKey(t => t.CountryId);
            });

            //Player
            modelBuilder.Entity<Player>(entity =>
            {
                //Teams
                entity.HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TeamId);

                //Positions
                entity.HasOne(p => p.Position)
                .WithMany(ps => ps.Players)
                .HasForeignKey(p => p.PositionId);
            });

            //PlayerStatistic
            modelBuilder.Entity<PlayerStatistic>(entity =>
            {
                //Many to many relationship

                entity.HasKey(g => new { g.GameId, g.PlayerId });

                entity.HasOne(g => g.Game)
                .WithMany(ps => ps.PlayerStatistics)
                .HasForeignKey(g => g.GameId);

                entity.HasOne(p => p.Player)
                .WithMany(ps => ps.PlayerStatistics)
                .HasForeignKey(p => p.PlayerId);
            });

            //Bet
            modelBuilder.Entity<Bet>(entity =>
            {
                entity.HasOne(b => b.Game)
                .WithMany(g => g.Bets)
                .HasForeignKey(b => b.GameId);

                entity.HasOne(b => b.User)
                .WithMany(u => u.Bets)
                .HasForeignKey(b => b.UserId);
            });
        }
    }
}
