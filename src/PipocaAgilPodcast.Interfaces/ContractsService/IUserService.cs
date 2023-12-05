using PipocaAgilPodcast.Application.DTOs;
using PipocaAgilPodcast.Domain;

namespace PipocaAgilPodcast.Interfaces.ContractsServices;

    public interface IUserService
    {
        Task<UserDTO[]> GetAllUsersAsync(CancellationToken cancellationToken = default);
        Task<User> GetUserByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<UserDTO> GetUserByUserNameAsync(string userName, CancellationToken cancellationToken = default);
    }
