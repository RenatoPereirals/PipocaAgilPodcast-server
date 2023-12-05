using System.Data.Common;
using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly IRepositoryPesistence _repositoryPesistence;

        public UserController(IUserService userService,
                              IUserRepository userRepository,
                              IMapper mapper,
                              IRepositoryPesistence repositoryPesistence)
        {
            _mapper = mapper;
            _repositoryPesistence = repositoryPesistence;
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
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
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
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
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
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserDTO model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var user = await _userRepository.AddUser(model);
                if (user == null) return NoContent();

                return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
            }
            catch (DbException ex)
            {
                return Conflict(new { Message = $"Usuário já existe. Error {ex}" });

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UserDTO model)
        {
            try
            {
                var existingUser = await _userRepository.UpdateUser(id, model);
                if (existingUser == null) return NoContent();

                _mapper.Map(_mapper, existingUser);

                await _repositoryPesistence.SaveChangesAsync();

                return Ok(existingUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var existingUser = await _userService.GetUserByIdAsync(id);
                if (existingUser == null) return NoContent();

                await _userRepository.DeleteUser(id);


                return Ok(existingUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}
