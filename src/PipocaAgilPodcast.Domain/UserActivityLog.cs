namespace PipocaAgilPodcast.Domain;
    public class UserActivityLog
    {
        public int UserId { get; set; }
        public required User Users { get; set; }
        public int ActivityLogId { get; set; }
        public required ActivityLog ActivityHistory { get; set; }
    }
