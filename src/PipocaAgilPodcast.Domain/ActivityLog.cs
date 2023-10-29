using PipocaAgilPodcast.Domain.Enum;

namespace PipocaAgilPodcast.Domain;
    public class ActivityLog
    {
        public ActivityLog() 
        {
            UsersActivitiesLogs = new List<UserActivityLog>();
        }
        public int Id { get; set; }
        public IEnumerable<UserActivityLog> UsersActivitiesLogs { get; set; }
        public ActivityType ActivityType { get; set; }
        public string ActivityDetails { get; set; } = string.Empty;
        public DateTime ActivityDate { get; set; }
        public string IPAddress { get; set; } = string.Empty;
    }
