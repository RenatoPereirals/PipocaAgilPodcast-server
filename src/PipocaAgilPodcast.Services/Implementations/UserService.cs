using Microsoft.EntityFrameworkCore;

using PipocaAgilPodcast.Domain;

using PipocaAgilPodcast.Persistence.Models;
using PipocaAgilPodcast.Interfaces.ContractsServices;

using PipocaAgilPodcast.Services.Error;
using PipocaAgilPodcast.Application.DTOs;
using AutoMapper;

namespace PipocaAgilPodcast.Services.Implementations
{
    public class UserService : IUserService
    { 
        public readonly PipocaAgilPodcastDbContext _context;
        public readonly IMapper  _mapper;
        public UserService(PipocaAgilPodcastDbContext context,
                           IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<UserDTO[]> GetAllUsersAsync(CancellationToken cancellationToken = default)
        {
            IQueryable<User> query = _context.Users.OrderBy(u => u.Id);
            var users = await query.ToListAsync(cancellationToken);

            return _mapper.Map<UserDTO[]>(users);
        }

        public async Task<UserDTO> GetUserByIdAsync(int userId, CancellationToken cancellationToken = default)
        {
            if (userId <= 0) throw new ArgumentException("O ID do usuário deve ser maior que zero.", nameof(userId));
        
             var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);

            if (user == null) throw new UserHandlingException("Id do usuário não encontrado.");        

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> GetUserByUserNameAsync(string userName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(userName)) throw new ArgumentException("O nome de usuário não pode estar vazio ou nulo.", nameof(userName));
            
            var normalizedUserName = userName.ToLower();
    
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserName.ToLower() == normalizedUserName, cancellationToken);

            if (user == null) throw new UserHandlingException("Nome de usuário não encontrado.");          

            return _mapper.Map<UserDTO>(user);
        }
        public async Task<UserDTO[]> GetUsersByInterestAsync(string interestName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(interestName)) throw new ArgumentException("O nome do interesse não pode estar vazio ou nulo.", nameof(interestName));
          
            var users = await _context.Users
                .Include(u => u.Interests)
                .Where(u => u.Interests != null && u.Interests.Any(i => i.Topic == interestName))
                .ToListAsync(cancellationToken);
            
            if (users == null) throw new UserHandlingException("Nome de interesse não encontrados.");

            return _mapper.Map<UserDTO[]>(users);           
        }  
    }
}