using Microsoft.AspNetCore.Identity;
using PipocaAgilPodcast.Domain;

namespace PipocaAgilPodcast.Authentication;

public class ApplicationUser : IdentityUser<int>
{
    public ApplicationUser()
    {
        Permissions = new List<Permission>();
        ActivityHistory = new List<ActivityLog>();
        Interests = new List<Interest>();
        RegistrationDate = DateTime.UtcNow;
    } 
    
    public string FullName { get; set; }  = string.Empty;
    public string Username { get;  set; }  = string.Empty;
    public new string? Email { get; set; }
    public new string? PasswordHash  { get; set; }
    public  DateTime RegistrationDate { get; set; }
    public DateTime LastAccess { get; set; }
    public bool IsActive { get; set; }
    public string ImageURL { get; set; } = string.Empty;
    public IEnumerable<Permission> Permissions { get; set; }
    public IEnumerable<ActivityLog> ActivityHistory { get; set; }
    public IEnumerable<Interest> Interests { get; set; }
}
    
