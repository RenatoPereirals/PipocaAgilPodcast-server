namespace PipocaAgilPodcast.Domain.Identity;

    public class Role
    {
        public Role() 
        {
            UsersRoles = new List<UserRole>();
        }
        public IEnumerable<UserRole> UsersRoles { get; set; }
    }
