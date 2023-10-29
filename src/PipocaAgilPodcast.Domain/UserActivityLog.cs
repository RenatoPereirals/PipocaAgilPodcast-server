namespace PipocaAgilPodcast.Domain;
    public class UserActivityLog
    {
        public int UserId { get; set; }
        public virtual required User Users { get; set; }
        public int ActivityLogId { get; set; }
        public virtual required ActivityLog UsersActivitiesLogs { get; set; }
    }
