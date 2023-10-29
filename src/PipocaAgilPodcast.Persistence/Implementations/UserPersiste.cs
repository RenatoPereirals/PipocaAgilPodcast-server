using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PipocaAgilPodcast.Domain;
using PipocaAgilPodcast.Interfaces.ContractsPersistence;

namespace PipocaAgilPodcast.Persistence.Implementations
{
    public class UserPersiste : IUserPersistence
    {
        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void DeleteRange<T>(T[] entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByUserNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}