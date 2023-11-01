using Microsoft.EntityFrameworkCore;
using PipocaAgilPodcast.Domain;
using PipocaAgilPodcast.Interfaces.ContractsPersistence;
using PipocaAgilPodcast.Persistence.Models;
using PipocaAgilPodcast.Services.Error;

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
                .FirstOrDefaultAsync(u => u.Id == userId) ?? throw new UserHandlingException("Id do usuário não encontrado.");

            return user;
        }
        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            var normalizedUserName = userName.ToLower();
    
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserName.ToLower() == normalizedUserName) ?? throw new UserHandlingException("Nome de usuário não encontrado.");

            return user;
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