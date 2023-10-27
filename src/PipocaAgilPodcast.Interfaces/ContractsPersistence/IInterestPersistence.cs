using PipocaAgilPodcast.Domain;

namespace PipocaAgilPodcast.Interfaces.ContractsPersistence;
    public interface IInterestPersistence
    {
        Task<IEnumerable<Interest>> GetInterestsAsync();
        Task<Interest> GetInterestByIdAsync(int id);
        Task<IEnumerable<Interest>> GetInterestsForUserAsync(int userId);
        Task<IEnumerable<Interest>> SearchInterestsByTopicAsync(string topic);
    }
