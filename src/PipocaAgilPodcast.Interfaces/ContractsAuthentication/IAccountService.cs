using Microsoft.AspNetCore.Identity;
using PipocaAgilPodcast.Application.DTOs;

namespace PipocaAgilPodcast.Interfaces.ContractsAuthentication
{
    public interface IAccountService
    {
        Task<bool> UserExists(string username);
        Task<UserUpdateDTO> GetUserByUserNameAsync(string username);
        Task<SignInResult> CheckUserPasswordAsync(UserUpdateDTO userUpdateDto, string password);
        Task<UserUpdateDTO> CreateAccountAsync(UserDTO userDto);
        Task<UserUpdateDTO> UpdateAccount(UserUpdateDTO userUpdateDto);
    }
}