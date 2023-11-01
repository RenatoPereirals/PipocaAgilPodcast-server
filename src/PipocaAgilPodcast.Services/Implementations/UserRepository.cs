using System.ComponentModel.DataAnnotations;
using System.Data.Common;
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
                response.StatusCode = 201; // Created
                response.Message = "Usuário criado com sucesso.";
            }
           catch (Exception ex)
            {
                if (ex is DbException dbException)
                {
                    if (dbException.Message.Contains("unique constraint violation"))
                    {
                        throw new UserAlreadyExistsException("Usuário já está cadastrado.", dbException, 409);
                    }
                    else
                    {
                        throw new UserCreationException("Erro ao criar o usuário.", dbException, 500);
                    }
                }
                else if (ex is ValidationException validationException)
                {
                    throw new UserValidationException("Erro ao validar o cadastro.", validationException, 400);
                }
                else
                {
                    throw new UserHandlingException("Erro inesperado ao criar o usuário.", ex);
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
                response.StatusCode = 200; // OK
                response.Message = "Usuário atualizado com sucesso.";
            }
            catch (DbException ex)
            {
                throw new UserUpdatedException("Erro ao atualizar cadastro.", ex, 500); // Internal Server Error
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
                response.StatusCode = 204; // No Content
                response.Message = "Usuário deletado com sucesso.";
            }
            catch (DbException ex)
            {
                throw new UserDeletedException("Erro ao deletar usuário.", ex, 500); // Internal Server Error
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
                response.StatusCode = 204; // No Content
                response.Message = "Usuários deletados com sucesso.";
            }
            catch (DbException ex)
            {
                throw new UserDeletedException("Erro ao deletar usuários.", ex, 500); // Internal Server Error
            }

            return response;
        }
    }
}