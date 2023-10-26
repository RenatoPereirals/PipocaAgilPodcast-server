using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PipocaAgilPodcast.Domain.Identity;

    public class User
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
