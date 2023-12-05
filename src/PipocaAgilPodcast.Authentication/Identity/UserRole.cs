using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace PipocaAgilPodcast.Authentication.Identity
{
    public class UserRole : IdentityUserRole<int>
    {
        public UserAuth UserAuths { get; set; }
        public Role Roles { get; set; }

        public UserRole()
        {
            UserAuths = new UserAuth();
            Roles = new Role();
        }
    }
}