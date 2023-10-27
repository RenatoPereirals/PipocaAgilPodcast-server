namespace PipocaAgilPodcast.Interfaces.ContractsPersistence
{
    public interface IUserPersistence : IRepositoryPesistence
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByUserNameAsync(string userName);
    }
}