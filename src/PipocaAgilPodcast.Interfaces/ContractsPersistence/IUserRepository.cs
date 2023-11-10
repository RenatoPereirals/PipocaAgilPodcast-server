using PipocaAgilPodcast.Application.DTOs;

namespace PipocaAgilPodcast.Interfaces.ContractsPersistence;

    public interface IUserRepository
    {
        Task<UserDTO> AddUser(UserDTO model);
        Task<UserDTO> UpdateUser(int userId, UserDTO model);
        Task<bool> DeleteUser(int userId, UserDTO model);
    }
