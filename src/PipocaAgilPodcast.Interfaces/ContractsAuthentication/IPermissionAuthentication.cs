using PipocaAgilPodcast.Authentication;

namespace PipocaAgilPodcast.Interfaces.Authentication;

    public interface IPermissionAuthentication
    {
        Task<IEnumerable<Permission>> GetAllPermissionsAsync();
        Task<Permission> GetPermissionByIdAsync(int id);
        Task<IEnumerable<Permission>> GetPermissionsByUserAsync(int userId);
        Task<IEnumerable<Permission>> GetRolePermissionsAsync(string roleName);
        Task<IEnumerable<Permission>> GetPermissionsIsActiveAsync(bool isActive = true);
    }
