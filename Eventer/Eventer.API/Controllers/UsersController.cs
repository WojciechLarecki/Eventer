using Eventer.API.Logging;
using Eventer.Logic.DTOs;
using Eventer.Logic.DTOs.CreateDTOs;
using Eventer.Logic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Eventer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _service;
        private readonly IRequestLogger<UsersController> _logger;

        public UsersController(IRequestLogger<UsersController> logger, UserService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            var users = (await _service.GetUsersAsync()).ToList();
            
            if (users.Count == 0)
            {
                _logger.LogNoContent();
                return NoContent();
            }

            return Ok(users);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetUserAsync(Guid id)
        {
            var user = await _service.GetUser(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(UserCreateDTO userDTO)
        {
            var dto = await _service.CreateUserAsync(userDTO);
            return Ok(dto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserAsync(UserDTO userDTO)
        {
            await _service.UpdateUserAsync(userDTO);
            return Ok();
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteUserAsync(Guid id)
        {
            await _service.DeleteUserAsync(id);
            
            return Ok();
        }

        [HttpPost("/Events/{eventId:Guid}/Users/{userId:Guid}")]
        public async Task<IActionResult> AddUserToEventAsync(Guid eventId, Guid userId)
        {
            await _service.AddUserToEventAsync(eventId, userId);

            return Ok();
        }

        [HttpDelete("/Events/{eventId:Guid}/Users/{userId:Guid}")]
        public async Task<IActionResult> DeleteUserFromEventAsync(Guid eventId, Guid userId)
        {
            await _service.DeleteUserFromEventAsync(eventId, userId);

            return Ok();
        }
    }
}
