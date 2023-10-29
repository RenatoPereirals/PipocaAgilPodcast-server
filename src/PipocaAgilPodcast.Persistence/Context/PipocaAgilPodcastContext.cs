using Microsoft.EntityFrameworkCore;
using PipocaAgilPodcast.Domain;

namespace PipocaAgilPodcast.Persistence.Context;

    public class PipocaAgilPodcastContext : DbContext
    {
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
