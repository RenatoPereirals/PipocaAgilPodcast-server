using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PipocaAgilPodcast.Application.DTOs
{
    public class UserUpdateDTO
    {
        public string FullName { get; set; }
        public string UserName  { get; set; } 
        public string? ImageURL { get; set; }
        public DateTime DateOfBirth { get; set; }
        public  DateTime RegistrationDate { get; private set; }
        public DateTime LastAccess { get; private set; }

        public UserUpdateDTO()
        {
            FullName = string.Empty;
            UserName = string.Empty;
        }
    }
}