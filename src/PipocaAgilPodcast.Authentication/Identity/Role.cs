using Microsoft.AspNetCore.Identity;

namespace PipocaAgilPodcast.Authentication.Identity
{
    public class Role : IdentityRole<int>
    {
        public List<UserRole> UserRoles { get; set; }

        public Role()
        {
            UserRoles = new List<UserRole>();
        }
    }
}