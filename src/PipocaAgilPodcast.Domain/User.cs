namespace PipocaAgilPodcast.Domain;

    public class User
    {
    public User(string fullName, string userName, string imageURL, DateTime dateOfBirth, DateTime registrationDate, DateTime lastAccess, IEnumerable<Interest>? interests, ActivityStatistics? statistics, IEnumerable<UserActivityLog>? usersActivitiesLogs)
    {
        FullName = fullName ?? throw new ArgumentNullException(nameof(fullName));
        UserName = userName ?? throw new ArgumentNullException(nameof(userName));
        ImageURL = imageURL ?? throw new ArgumentNullException(nameof(imageURL));
        DateOfBirth = dateOfBirth;
        RegistrationDate = registrationDate;
        LastAccess = lastAccess;
        Interests = interests;
        Statistics = statistics;
        UsersActivitiesLogs = usersActivitiesLogs;
    }

        public int Id { get; set; }
        public string? FullName { get; set; }
        public string UserName  { get; set; } 
        public string ImageURL { get; set; }
        public DateTime DateOfBirth { get; set; }
        public  DateTime RegistrationDate { get; set; }
        public DateTime LastAccess { get; set; }
        public virtual IEnumerable<Interest>? Interests { get; set; }
        public virtual ActivityStatistics? Statistics { get; set; }
        public IEnumerable<UserActivityLog>? UsersActivitiesLogs { get; set; }
    }