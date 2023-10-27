using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PipocaAgilPodcast.Interfaces.ContractsPersistence
{
    public interface IInterestPersistence
    {
        Task<IEnumerable<Interest>> GetInterestsAsync();
        Task<Interest> GetInterestByIdAsync(int id);
        Task<IEnumerable<Interest>> GetInterestsForUserAsync(int userId);
        ask<IEnumerable<Interest>> SearchInterestsByTopicAsync(string topic);
    }
}