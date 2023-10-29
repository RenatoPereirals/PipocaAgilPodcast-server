using PipocaAgilPodcast.Domain.Enum;

namespace PipocaAgilPodcast.Domain;

    public class User
    {
        public User() 
        {
            UsersActivitiesLogs = new List<UserActivityLog>();
        }
        
        public string FullName { get; set; } = string.Empty;
        public string ImageURL { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public virtual Interest? Interests { get; set; }
        public virtual ActivityStatistics? Statistics { get; set; }
        public IEnumerable<UserActivityLog> UsersActivitiesLogs { get; set; }
    }
