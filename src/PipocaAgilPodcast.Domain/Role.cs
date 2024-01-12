using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PipocaAgilPodcast.Domain
{
    public class Role
    {
        public Role(string roles) 
        {
            Roles = roles;   
        }
        public string Roles { get; set; }
    }
}