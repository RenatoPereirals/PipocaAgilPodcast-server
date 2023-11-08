using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using PipocaAgilPodcast.Domain;

namespace tests.UnitTests.Persistence.Context;

    public class PipocaAgilPodcastDbContextTest : DbContext
    {
        public PipocaAgilPodcastDbContextTest(DbContextOptions<PipocaAgilPodcastDbContextTest> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ActivityLog> ActivityHistory { get; set; }
        public DbSet<ActivityStatistics> Statistics { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<UserActivityLog> UsersActivitiesLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura o entity models aqui
            modelBuilder.Entity<UserActivityLog>().HasKey(ua => new { ua.UserId, ua.ActivityLogId });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("DataSource=:memory:"); // SQLite in-memory database
            }
        }
    }

