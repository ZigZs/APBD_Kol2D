using APBD_KOL2C.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_KOL2C.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
        
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Map> Maps { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<Tournament> Tournaments { get; set; }
    public DbSet<PlayerMatch> PlayerMatches { get; set; }
    public DbSet<Player> Players { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Map>(m =>
            {
                m.HasKey(e => e.MapId);
                m.Property(e => e.Name).IsRequired().HasMaxLength(100);
                m.Property(e => e.Type).IsRequired().HasMaxLength(100);
            }
        );

        modelBuilder.Entity<Match>(m =>
            {
                m.HasKey(e => e.MatchId);
                m.HasOne(e => e.Map)
                    .WithMany()
                    .HasForeignKey(e => e.MapId);
                m.HasOne(e => e.Tournament)
                    .WithMany()
                    .HasForeignKey(e => e.TournamentId);
                m.Property(e => e.MatchDay).IsRequired();
                m.Property(e => e.Team1Score).IsRequired();
                m.Property(e => e.Team2Score).IsRequired();
                m.Property(e => e.BestRating).HasColumnType("decimal(4,2)");
            }
        );
        
        modelBuilder.Entity<PlayerMatch>(pm =>
            {
                pm.HasKey(e => new {e.MatchId, e.PlayerId});
                pm.HasOne(e => e.Match)
                    .WithMany()
                    .HasForeignKey(e => e.MatchId);
                pm.HasOne(e => e.Player)
                    .WithMany()
                    .HasForeignKey(e => e.PlayerId);
                pm.Property(e => e.MVPs).IsRequired();
                pm.Property(e => e.Rating).HasColumnType("decimal(4,2)");
            }
        );
        modelBuilder.Entity<Tournament>(t =>
            {
                t.HasKey(e => e.TournamentId);
                t.Property(e => e.Name).IsRequired();
                t.Property(e => e.StartDate).IsRequired();
                t.Property(e => e.EndDate).IsRequired();
            }
        );
        modelBuilder.Entity<Player>(p =>
            {
                p.HasKey(e => e.PlayerId);
                p.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                p.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                p.Property(e => e.BirthDay).IsRequired();
            }
        );
        
        modelBuilder.Entity<Player>().HasData(
            new Player()
            {
                PlayerId = 1,
                FirstName = "John",
                LastName = "Doe",
                BirthDay = new DateTime(2000, 3, 12),
            },
            new Player()
            {
                PlayerId = 2,
                FirstName = "Jane",
                LastName = "Doe",
                BirthDay = new DateTime(1980, 4, 2),
            }
        );

        modelBuilder.Entity<Map>().HasData(
            new Map()
            {
                MapId = 1,
                Name = "Stadion Legi",
                Type = "Stadion Klubu"
            },
            new Map()
            {
                MapId = 2,
                Name = "Stadion Narodowy",
                Type = "Stadion Państwowy"
            }
        );
        modelBuilder.Entity<Tournament>().HasData(
            new Tournament()
            {
                TournamentId = 1,
                Name = "La liga",
                StartDate = new DateTime(2024,03,02),
                EndDate = new DateTime(2025,03,02),
            },
            new Tournament()
            {
                TournamentId = 2,
                Name = "Uefa Euro",
                StartDate = new DateTime(2025,01,02),
                EndDate = new DateTime(2025,05,02),
            }
        );
        modelBuilder.Entity<Match>().HasData(
            new Match()
            {
                MatchId = 1,
                TournamentId = 1,
                MapId = 1,
                MatchDay = DateTime.Today,
                Team1Score = 3,
                Team2Score = 3,
                BestRating = 3.2m,

            },
            new Match()
            {
                MatchId = 2,
                TournamentId = 2,
                MapId = 2,
                MatchDay = DateTime.Today,
                Team1Score = 1,
                Team2Score = 3,
                BestRating = 2.5m,

            }
        );
        modelBuilder.Entity<PlayerMatch>().HasData(
            new PlayerMatch()
            {
                MatchId = 1,
                PlayerId = 1,
                MVPs = 3,
                Rating = 3.0m
            },
            new PlayerMatch()
            {
                MatchId = 2,
                PlayerId = 2,
                MVPs = 1,
                Rating = 2.1m
            }
        );
    }
}