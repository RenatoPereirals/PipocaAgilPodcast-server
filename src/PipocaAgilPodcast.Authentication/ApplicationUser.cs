using Microsoft.AspNetCore.Identity;
using PipocaAgilPodcast.Domain;

namespace PipocaAgilPodcast.Authentication;

public class ApplicationUser : IdentityUser<int>
{       
    public new string? Email { get; set; }
    public new string? PasswordHash  { get; set; }
       public bool IsActive { get; set; }
    public required Permission Permissions { get; set; }
}
    
