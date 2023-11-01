using PipocaAgilPodcast.Domain;

namespace PipocaAgilPodcast.Interfaces.ContractsPersistence;

    public interface IUserService
    {
        Task<User[]> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByUserNameAsync(string userName);
        Task<User[]> GetUsersByInterestAsync(string interestName);
    }
