using LuminariasWeb.sln.BusinessInterface;
using LuminariasWeb.sln.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LuminariasWeb.sln.Controllers
{
    [Route("api/User")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger _logger; 

        public UsersController(IUserService userService, ILogger logger) 
        {
            _userService = userService;
            _logger = logger; 
        }

        [HttpGet("GetAllUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetUsersAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los usuarios");
                return StatusCode(500);
            }
        }

        [HttpGet("GetUserById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserViewModel>> GetUserById(int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el usuario con ID: {id}");
                return StatusCode(500);
            }
        }

        [HttpPost("AddUser")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddUser([FromBody] UserViewModel userViewModel)
        {
            try
            {
                await _userService.AddUserAsync(userViewModel);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al agregar un nuevo usuario");
                return StatusCode(500);
            }
        }

        [HttpPut("UpdateUser/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserViewModel userViewModel)
        {
            try
            {
                var existingUser = await _userService.GetUserByIdAsync(id);
                if (existingUser == null)
                {
                    return NotFound();
                }

                await _userService.UpdateUserAsync(userViewModel);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar el usuario con ID: {id}");
                return StatusCode(500);
            }
        }

        [HttpDelete("DeleteUser/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var existingUser = await _userService.GetUserByIdAsync(id);
                if (existingUser == null)
                {
                    return NotFound();
                }

                await _userService.DeleteUserAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar el usuario con ID: {id}");
                return StatusCode(500);
            }
        }
    }
}

