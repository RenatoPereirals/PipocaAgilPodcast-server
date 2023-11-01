using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using Microsoft.Extensions.Logging;
using PipocaAgilPodcast.Domain;
using PipocaAgilPodcast.Interfaces.ContractsPersistence;
using PipocaAgilPodcast.Services.Error;

namespace PipocaAgilPodcast.Services.Implementations
{
    public class UserRepository
    {
         private readonly IRepositoryPesistence _userRepositoryPesistence;

        public UserRepository(IRepositoryPesistence userRepositoryPesistence)
        {
            _userRepositoryPesistence = userRepositoryPesistence;
        }

        public async Task<ServiceResponse> CreateUser(User user)
        {
            var response = new ServiceResponse();

            try
            {
                _userRepositoryPesistence.Add(user);
                await _userRepositoryPesistence.SaveChangesAsync();

                response.IsSuccess = true;
                response.StatusCode = 201; // return Created
                response.Message = "Usuário criado com sucesso.";
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

            return response;
        }

        public async Task<ServiceResponse> UpdateUser(User user)
        {
            var response = new ServiceResponse();

            try
            {
                _userRepositoryPesistence.Update(user);
                await _userRepositoryPesistence.SaveChangesAsync();

                response.IsSuccess = true;
                response.StatusCode = 200; // return OK
                response.Message = "Usuário atualizado com sucesso.";
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

                return response;
        }

        public async Task<ServiceResponse> DeleteUser(User user)
        {
            var response = new ServiceResponse();

            try
            {
                _userRepositoryPesistence.Delete(user);
                await _userRepositoryPesistence.SaveChangesAsync();

                response.IsSuccess = true;
                response.StatusCode = 204; // return No Content
                response.Message = "Usuário deletado com sucesso.";
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

            return response;
        }

        public async Task<ServiceResponse> DeleteRangeUser(User[] users)
        {
            var response = new ServiceResponse();

            try
            {
                _userRepositoryPesistence.DeleteRange(users);
                await _userRepositoryPesistence.SaveChangesAsync();

                response.IsSuccess = true;
                response.StatusCode = 204; // return No Content
                response.Message = "Usuários deletados com sucesso.";
            }
            catch (Exception ex)
            {
                if (ex is DbException dbException)
                {
                    throw new UserDeletedFailedException("Erro ao deletar o usuários.", dbException, 500); // return Internal Error Server             
                }
                else
                {
                    throw new UserHandlingException("Erro inesperado ao deletar os usuários.", ex); // returns an unexpected error 
                }
            }

            return response;
        }
    }
}