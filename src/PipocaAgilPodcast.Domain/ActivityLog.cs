using PipocaAgilPodcast.Domain.Enum;

namespace PipocaAgilPodcast.Domain;
    public class ActivityLog
    {
        public ActivityLog() 
        {
            UsersActivityLogs = new List<UserActivityLog>();
        }
        public int Id { get; set; }
        public IEnumerable<UserActivityLog> UsersActivityLogs { get; set; }
        public ActivityType ActivityType { get; set; }
        public string ActivityDetails { get; set; } = string.Empty;
        public DateTime ActivityDate { get; set; }
        public string IPAddress { get; set; } = string.Empty;
    }
