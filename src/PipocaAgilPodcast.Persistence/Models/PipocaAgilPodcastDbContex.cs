using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PipocaAgilPodcast.Domain;

namespace PipocaAgilPodcast.Persistence.Models;

    public partial class PipocaAgilPodcastDbContext : DbContext
    {

        public PipocaAgilPodcastDbContext(DbContextOptions<PipocaAgilPodcastDbContext> options) : base(options)
        {
        }

        public PipocaAgilPodcastDbContext()
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<ActivityLog> ActivityHistory => Set<ActivityLog>();
        public DbSet<ActivityStatistics> Statisticss => Set<ActivityStatistics>();
        public DbSet<Interest> Interests => Set<Interest>();
        public DbSet<UserActivityLog> UsersActivitiesLogs => Set<UserActivityLog>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserActivityLog>().HasKey(ua => new {ua.UserId, ua.ActivityLogId});
        }
    }

