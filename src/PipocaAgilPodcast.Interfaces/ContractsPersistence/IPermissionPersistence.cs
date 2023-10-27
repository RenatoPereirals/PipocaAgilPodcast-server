using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PipocaAgilPodcast.Interfaces.ContractsPersistence
{
    public interface IPermissionPersistence
    {
        Task<IEnumerable<Permission>> GetAllPermissionsAsync();
        Task<Permission> GetPermissionByIdAsync(int id);
        Task<IEnumerable<Permission>> GetPermissionsByUserAsync(int userId);
        Task<IEnumerable<Permission>> GetRolePermissionsAsync(string roleName);
        Task<IEnumerable<Permission>> GetPermissionsIsActiveAsync(bool isActive = true);
    }
}