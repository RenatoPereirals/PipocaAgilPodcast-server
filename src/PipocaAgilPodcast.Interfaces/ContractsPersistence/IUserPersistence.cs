using PipocaAgilPodcast.Domain;

namespace PipocaAgilPodcast.Interfaces.ContractsPersistence;

    public interface IUserPersistence
    {
        Task<User[]> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByUserNameAsync(string userName);
    }
