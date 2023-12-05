using Microsoft.AspNetCore.Identity;

namespace PipocaAgilPodcast.Authentication.Identity
{
    public class UserAuth : IdentityUser<int>
    {
        public string Username  { get; set; }
        public bool IsActive { get; set; } = false;
        public List<UserRole> UserRoles { get; set; }

        public UserAuth()
        {
            Username = string.Empty;
            UserRoles = new List<UserRole>();
        }
    }
}