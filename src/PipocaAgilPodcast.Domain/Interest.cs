namespace PipocaAgilPodcast.Domain;
    public class Interest
    {
        // public Interest()
        // {
        //     User = new User();
        // }
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string Topic { get; set; } = string.Empty;
        public int InterestLevel { get; set; }
        public DateTime CreatedAt { get; set; }
    }
