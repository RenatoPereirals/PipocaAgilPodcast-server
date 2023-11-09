using Microsoft.AspNetCore.Mvc;
using PipocaAgilPodcast.Application.DTOs;
using PipocaAgilPodcast.Interfaces.ContractsServices;
using PipocaAgilPodcast.Services.Error;

namespace PipocaAgilPodcast.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<UserDTO[]>> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao buscar os usuários: " + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                return Ok(user);
            }
            catch (UserHandlingException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao buscar o usuário: " + ex.Message);
            }
        }

        [HttpGet("UserName")]
        public async Task<ActionResult<UserDTO>> GetUserByUserName(string userName)
        {
            try
            {
                var user = await _userService.GetUserByUserNameAsync(userName);
                return Ok(user);
            }
            catch (UserHandlingException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao buscar o usuário por nome de usuário: " + ex.Message);
            }
        }

        [HttpGet("Interesse")]
        public async Task<ActionResult<UserDTO[]>> GetUsersByInterest(string interestName)
        {
            try
            {
                var users = await _userService.GetUsersByInterestAsync(interestName);
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao buscar os usuários por interesse: " + ex.Message);
            }
        }
    }
}
