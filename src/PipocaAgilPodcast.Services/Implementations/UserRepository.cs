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
            catch (ValidationException ex)
            {
                response.IsSuccess = false;
                response.StatusCode = 400; // Bad Request
                response.Message = "Erro ao validar o cadastro.";
                response.Data = ex.Message;
            }
            catch (DbException ex)
            {
                response.IsSuccess = false;
                response.StatusCode = 500; // Internal Server Error
                response.Message = "Erro ao criar o usuário.";
                response.Data = ex.Message;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.StatusCode = 409; // Conflict
                response.Message = "Usuário já está cadastrado.";
                response.Data = ex.Message;
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
                response.IsSuccess = false;
                response.StatusCode = 500; // Internal Server Error
                response.Message = "Erro ao atualizar o usuário.";
                response.Data = ex.Message;
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
                response.IsSuccess = false;
                response.StatusCode = 500; // Internal Server Error
                response.Message = "Erro ao deletar o usuário.";
                response.Data = ex.Message;
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
                response.IsSuccess = false;
                response.StatusCode = 500; // Internal Server Error
                response.Message = "Erro ao deletar usuários.";
                response.Data = ex.Message;
            }

            return response;
        }
    }
}