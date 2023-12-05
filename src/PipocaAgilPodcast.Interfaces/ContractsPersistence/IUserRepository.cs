using PipocaAgilPodcast.Application.DTOs;

namespace PipocaAgilPodcast.Interfaces.ContractsPersistence;

    public interface IUserRepository
    {
        Task<UserDTO> AddUser(UserDTO model);
        Task<UserUpdateDTO> UpdateUser(int id, UserUpdateDTO model);
        Task<bool> DeleteUser(int userId);
    }
