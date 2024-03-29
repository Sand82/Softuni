﻿using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {

        }

        public FootballBettingContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Color> Colors  { get; set; }
        public DbSet<Town> Towns  { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics  { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;User Id=sa;Password=@Test123456;Database=FootballBookmakerSystem");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().HasOne(x => x.PrimaryKitColor).WithMany(x => x.PrimaryKitTeams).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Team>().HasOne(x => x.SecondaryKitColor).WithMany(x => x.SecondaryKitTeams).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Team>().HasOne(x => x.Town).WithMany(x => x.Teams).OnDelete(DeleteBehavior.NoAction);            

            modelBuilder.Entity<Game>().HasOne(x => x.HomeTeam).WithMany(x => x.HomeGames).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Game>().HasOne(x => x.AwayTeam).WithMany(x => x.AwayGames).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Town>().HasOne(x => x.Country).WithMany(x => x.Towns);
            
            modelBuilder.Entity<Player>().HasOne(x => x.Team).WithMany(x => x.Players);

            modelBuilder.Entity<Player>().HasOne(x => x.Position).WithMany(x => x.Players);

            modelBuilder.Entity<Player>().HasMany(x => x.PlayerStatistics);

            modelBuilder.Entity<Game>().HasMany(x => x.PlayerStatistics);

            modelBuilder.Entity<Bet>().HasOne(x => x.Game).WithMany(x => x.Bets);

            modelBuilder.Entity<Bet>().HasOne(x => x.User).WithMany(x => x.Bets);

            modelBuilder.Entity<PlayerStatistic>().HasKey(x => new { x.PlayerId, x.GameId });

        }
    }
}
