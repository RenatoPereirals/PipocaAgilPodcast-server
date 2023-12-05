using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using AutoMapper;
using PipocaAgilPodcast.Application.DTOs;
using PipocaAgilPodcast.Domain;
using PipocaAgilPodcast.Interfaces.ContractsPersistence;
using PipocaAgilPodcast.Interfaces.ContractsServices;
using PipocaAgilPodcast.Services.Error;

namespace PipocaAgilPodcast.Services.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly IRepositoryPesistence _repositoryPersistence;
        private readonly IUserService _userService;
        public readonly IMapper _mapper;

        public UserRepository(IRepositoryPesistence userRepositoryPesistence,
                              IUserService userService,
                              IMapper mapper)
        {
            _repositoryPersistence = userRepositoryPesistence;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<UserDTO> AddUser(UserDTO model)
        {
            try
            {
                var user = _mapper.Map<User>(model);
                _repositoryPersistence.Add(user);
                await _repositoryPersistence.SaveChangesAsync();

                var userDto = _mapper.Map<UserDTO>(user);

                return userDto;
            }
           catch (Exception ex)
            {
                if (ex is DbException dbException)
                {
                    if (dbException.Message.Contains("unique constraint violation"))
                    {
                        throw new UserAlreadyExistsException("Usuário já está cadastrado.", dbException, 409); // return conflict
                    }
                    else
                    {
                        throw new UserCreationException("Erro ao criar o usuário.", dbException, 500); // return Internal Error Server 
                    }
                }
                else if (ex is ValidationException validationException)
                {
                    throw new UserValidationFailedException("Erro ao validar o cadastro.", validationException, 400); // return Bad Request
                }
                else
                {
                    throw new UserHandlingException("Erro inesperado ao criar o usuário.", ex); // returns an unexpected error 
                }
            }
        }

        public async Task<UserDTO> UpdateUser(int id, UserUpdateDTO model)
        {
            try
            {
                var user = _mapper.Map<User>(model);
                _repositoryPersistence.Update(user);
                await _repositoryPersistence.SaveChangesAsync();

                var userDto = _mapper.Map<UserDTO>(user);

                return userDto;


                // var userDto = _mapper.Map<UserDTO>(existingUser);

                throw new UserHandlingException("Usuário não encontrado.");;

            }
            catch (Exception ex)
            {
                if (ex is DbException dbException)
                {
                    throw new UserCreationException("Erro ao atualizar o usuário.", dbException, 500); // return Internal Error Server            
                }
                else if (ex is ValidationException validationException)
                {
                    throw new UserValidationFailedException("Erro ao validar a atualização do cadastro.", validationException, 400); // return Bad Request
                }
                else
                {
                    throw new UserHandlingException("Erro inesperado ao atualizar o usuário.", ex); // returns an unexpected error 
                }
            }
        }

        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                var existingUser = await _userService.GetUserByIdAsync(id);

                 if (existingUser == null) throw new UserHandlingException("Usuário não encontrado");

                _repositoryPersistence.Delete(existingUser); // Deleta o usuário
                await _repositoryPersistence.SaveChangesAsync(); // Salva as mudanças

                return true;
            }
            catch (Exception ex)
            {
                if (ex is DbException dbException)
                {
                    throw new UserDeletedFailedException("Erro ao deletar o usuário.", dbException, 500); // return Internal Error Server             
                }
                else
                {
                    throw new UserHandlingException("Erro inesperado ao deletar o usuário.", ex); // returns an unexpected error 
                }
            }
        }
    }
}