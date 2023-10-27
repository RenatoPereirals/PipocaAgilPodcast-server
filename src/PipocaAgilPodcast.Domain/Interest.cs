namespace PipocaAgilPodcast.Domain;
    public class Interest
    {
        public int Id { get; set; }
        public required User User { get; set; }
        public string Topic { get; set; } = string.Empty;
        public int InterestLevel { get; set; }
        public DateTime CreatedAt { get; set; }
    }
