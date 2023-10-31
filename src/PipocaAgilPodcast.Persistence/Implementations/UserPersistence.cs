using Microsoft.EntityFrameworkCore;
using PipocaAgilPodcast.Domain;
using PipocaAgilPodcast.Interfaces.ContractsPersistence;
using PipocaAgilPodcast.Persistence.Models;

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
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == userId);

            return user ?? new User();
        }
        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            var normalizedUserName = userName.ToLower();
    
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserName.ToLower() == normalizedUserName);

            return user ?? new User();
        }
        public async Task<User[]> GetUsersByInterestAsync(string interestName)
        {
             var users = await _context.Users
            .Include(u => u.Interests)
            .Where(u => u.Interests != null && u.Interests.Any(i => i.Topic == interestName))
            .ToListAsync();

            return users.ToArray();
        }
    }
}