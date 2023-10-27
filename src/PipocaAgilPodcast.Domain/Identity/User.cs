using Microsoft.AspNetCore.Identity;

namespace PipocaAgilPodcast.Domain.Identity;

    public class User : IdentityUser<int>
    {
        public User()
        {
            UsersRoles = new List<UserRole>();
        }
        public string FullName { get; set; } = string.Empty;
        public string ImageURL { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public List<UserRole> UsersRoles { get; set; }
    }
