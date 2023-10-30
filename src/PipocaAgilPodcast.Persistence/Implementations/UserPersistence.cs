using Microsoft.EntityFrameworkCore;
using PipocaAgilPodcast.Domain;
using PipocaAgilPodcast.Interfaces.ContractsPersistence;
using PipocaAgilPodcast.Persistence.Models;
using SQLitePCL;

namespace PipocaAgilPodcast.Persistence.Implementations
{
    public class UserPersistence : IUserPersistence
    { 
        public readonly PipocaAgilPodcastDbContext _context;
        public UserPersistence(PipocaAgilPodcastDbContext context) => _context = context;

        public async Task<User[]> GetAllUsersAsync()
        {
            IQueryable<User> query = _context.Users;

            query = query.OrderBy(u => u.Id);

            return await query.ToArrayAsync();
        }
        public async Task<User> GetUserByIdAsync(int userId)
        {
            IQueryable<User> query = _context.Users;

            query = query.OrderBy(u => u.Id)
                .Where(u => u.Id == userId);

            return await query.FirstOrDefaultAsync() ?? new User();
        }
        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            IQueryable<User> query = _context.Users;

            query = query.OrderBy(u => u.Id)
                .Where(u => u.UserName.ToLower()
                .Contains(userName.ToLower()));

            return await query.FirstOrDefaultAsync() ?? new User();
        }

    }
}