namespace PipocaAgilPodcast.Domain;

     public class ActivityStatistics
    {
         public ActivityStatistics()
        {
            User = new User();
            UsersActivitiesLogs = new ActivityLog();
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual  User User { get; set; }
        public int ActivityLogId { get; set; }
        public virtual  ActivityLog UsersActivitiesLogs { get; set; }
        public int TotalActivities { get; set; }
        public int TotalLikes { get; set; }
        public int TotalComments { get; set; }
        public int TotalShares { get; set; }
    }
