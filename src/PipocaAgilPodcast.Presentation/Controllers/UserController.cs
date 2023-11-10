using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using PipocaAgilPodcast.Application.DTOs;
using PipocaAgilPodcast.Interfaces.ContractsPersistence;
using PipocaAgilPodcast.Interfaces.ContractsServices;
using PipocaAgilPodcast.Services.Error;

namespace PipocaAgilPodcast.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;

        public UserController(IUserService userService,
                              IUserRepository userRepository)
        {
            _userService = userService;
            _userRepository = userRepository;
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

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserDTO model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
    
                var user = await _userRepository.AddUser(model);

                return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
            }
            catch (DbException ex)
            {
                // Trate a violação de chave única
                return Conflict(new { Message = $"Usuário já existe. Error {ex}" });

            }
            catch (Exception ex)
            {
                // Trate outras exceções
                return StatusCode(500, new { Message = $"Erro ao processar a solicitação. Error {ex}" });

            }
        }
    }
}
