namespace PipocaAgilPodcast.API.Models;

    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string DateOfBirth { get; set; } = string.Empty;
    }
