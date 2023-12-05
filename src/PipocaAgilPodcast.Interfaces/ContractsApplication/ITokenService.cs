using PipocaAgilPodcast.Application.DTOs;

namespace PipocaAgilPodcast.Interfaces.ContractsApplication
{
    public interface ITokenService
    {
        Task<string> CreateToken(UserUpdateDTO userUpdateDto);
    }
}