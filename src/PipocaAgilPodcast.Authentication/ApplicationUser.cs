using Microsoft.AspNetCore.Identity;

namespace PipocaAgilPodcast.Authentication;

public class ApplicationUser : IdentityUser<int>
{    
    public bool IsActive { get; set; } 
}
    
