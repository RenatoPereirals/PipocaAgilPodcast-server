using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PipocaAgilPodcast.Domain.Identity;

    public class UserRole
    {
     
        public required User Users { get; set; }
        public required Role Roles { get; set; }
    }
