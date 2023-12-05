using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PipocaAgilPodcast.Application.DTOs
{
    public class UserLoginDto
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public UserLoginDto(string email, string username, string password)
        {
            Email = email;
            Username = username;
            Password = password;
        }
    }
}