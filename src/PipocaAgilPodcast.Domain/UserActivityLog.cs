namespace PipocaAgilPodcast.Domain;
    public class UserActivityLog
    {
        // public UserActivityLog()
        // {
        //     Users = new User();
        //     UsersActivitiesLogs = new ActivityLog();
        // }
        public int UserId { get; set; }
        public virtual User Users { get; set; }
        public int ActivityLogId { get; set; }
        public virtual ActivityLog UsersActivitiesLogs { get; set; }
    }
