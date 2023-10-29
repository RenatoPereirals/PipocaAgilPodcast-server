using PipocaAgilPodcast.Domain.Enum;

namespace PipocaAgilPodcast.Domain;

    public class User
    {
        public User() 
        {
            UsersActivityLogs = new List<UserActivityLog>();
            Interests = new List<Interest>();
            Statistics = new List<ActivityStatistics>();
        }
        
        public string FullName { get; set; } = string.Empty;
        public string ImageURL { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public IEnumerable<UserActivityLog> UsersActivityLogs { get; set; }
        public IEnumerable<Interest> Interests { get; set; }
        public IEnumerable<ActivityStatistics> Statistics { get; set; }
    }
