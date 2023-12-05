using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace PipocaAgilPodcast.Authentication.Identity
{
    public class User : IdentityUser<int>
    {
        public string FullName { get; set; }
        public string UserName  { get; set; } 
        public string? ImageURL { get; set; }
        public DateTime DateOfBirth { get; set; }
        public  DateTime RegistrationDate { get; private set; }
        public DateTime LastAccess { get; private set; }
        public bool IsActive { get; set; } 
        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}