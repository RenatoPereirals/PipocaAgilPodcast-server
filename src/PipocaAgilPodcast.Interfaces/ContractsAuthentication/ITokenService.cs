using PipocaAgilPodcast.Application.DTOs;

namespace PipocaAgilPodcast.Interfaces.ContractsAuthentication
{
    public interface ITokenService
    {
        Task<string> CreateToken(UserUpdateDTO userUpdateDto);
    }
}