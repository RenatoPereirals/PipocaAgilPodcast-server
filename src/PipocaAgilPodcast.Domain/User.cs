using PipocaAgilPodcast.Domain.Enum;

namespace PipocaAgilPodcast.Domain;

    public class User
    {
        public string FullName { get; set; } = string.Empty;
        public string ImageURL { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
    }
