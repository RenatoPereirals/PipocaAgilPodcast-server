using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PipocaAgilPodcast.Application.DTOs;
using PipocaAgilPodcast.Authentication.Identity;
using PipocaAgilPodcast.Domain;
using PipocaAgilPodcast.Interfaces.ContractsAuthentication;
using PipocaAgilPodcast.Interfaces.ContractsPersistence;
using PipocaAgilPodcast.Interfaces.ContractsServices;

namespace PipocaAgilPodcast.Authentication.Implementations
{
    public class AccountService : IAccountService
    {
        
        private readonly UserManager<UserAuth> _userManager;
        private readonly SignInManager<UserAuth> _signInManager;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IRepositoryPesistence _repository;

        public AccountService(UserManager<UserAuth> userManager,
                              SignInManager<UserAuth> signInManager,
                              IMapper mapper,
                              IUserService userPersist,
                              IRepositoryPesistence Repository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _userService = userPersist;
            _repository = Repository;
        }

        public async Task<SignInResult> CheckUserPasswordAsync(UserUpdateDTO userUpdateDto, string password)
        {
            try
            {
                var user = await _userManager.Users
                                             .SingleOrDefaultAsync(user => user.UserName == userUpdateDto.UserName.ToLower());

                if(user == null) throw new Exception("Usuário não encontrado");

                return await _signInManager.CheckPasswordSignInAsync(user, password, false);
                     
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar verificar a senha do usuário. Erro: {ex.Message}");
            }
        }

        public async Task<UserUpdateDTO> CreateAccountAsync(UserDTO userDto)
        {
            try
            {
                var user = _mapper.Map<UserAuth>(userDto);
                var result = await _userManager.CreateAsync(user, userDto.Password);

                if (result.Succeeded)
                {
                    var userToReturn = _mapper.Map<UserUpdateDTO>(user);
                    return userToReturn;
                }

                throw new Exception("Usuário não encontrado");;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar criar um usuário. Erro: {ex.Message}");
            }
        }

        public async Task<UserUpdateDTO> GetUserByUserNameAsync(string userName)
        {
            try
            {
                var user = await _userService.GetUserByUserNameAsync(userName);

                if (user == null)
                    throw new Exception("Usuário não encontrado");;

                var userUpdateDto = _mapper.Map<UserUpdateDTO>(user);
                return userUpdateDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar obter o usuário pelo nome de usuário. Erro: {ex.Message}");
            }
        }

        public async Task<UserUpdateDTO> UpdateAccount(UserUpdateDTO userUpdateDto)
        {
            try
            {
                var user = await _userService.GetUserByUserNameAsync(userUpdateDto.UserName);

                if (user == null) throw new Exception("Usuário não encontrado");; 
                
                userUpdateDto.Id = user.Id;

                UserAuth updatedUser = new UserAuth 
                {
                    UserName = userUpdateDto.UserName,
                    Email = userUpdateDto.Email,
                    PasswordHash = userUpdateDto.Password
                };

                _mapper.Map(updatedUser, user);

                if (userUpdateDto.Password != null) {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(updatedUser);
                    await _userManager.ResetPasswordAsync(updatedUser, token, userUpdateDto.Password);
                }
                
                _repository.Update<UserAuth>(updatedUser);

                if (await _repository.SaveChangesAsync())
                {
                    var userRetorno = await _userService.GetUserByUserNameAsync(user.UserName);

                    return _mapper.Map<UserUpdateDTO>(userRetorno);
                }

                throw new Exception("Usuário não encontrado");;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar atualizar o usuário. Erro: {ex.Message}");
            }
        }

        public async Task<bool> UserExists(string userName)
        {
            try
            {
                return await _userManager.Users.AnyAsync(user => user.UserName == userName.ToLower());
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar verificar se o usuário existe. Erro: {ex.Message}");
            }
        }
    }
}