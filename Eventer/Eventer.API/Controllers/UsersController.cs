using Eventer.API.Logging;
using Eventer.Data.Exceptions;
using Eventer.Data.Models;
using Eventer.Logic.DTOs;
using Eventer.Logic.DTOs.CreateDTOs;
using Eventer.Logic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

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
        public IActionResult DeleteUser(Guid id)
        {
            _service.DeleteUser(id);
            return Ok();
        }

        [HttpPost("/Events/{eventId:Guid}/Users/{userId:Guid}")]
        public IActionResult AddUserToEvent(Guid eventId, Guid userId)
        {
            _service.AddUserToEvent(eventId, userId);

            return Ok();
        }

        [HttpDelete("/Events/{eventId:Guid}/Users/{userId:Guid}")]
        public IActionResult DeleteUserFromEvent(Guid eventId, Guid userId)
        {
            _service.DeleteUserFromEvent(eventId, userId);

            return Ok();
        }
    }
}
