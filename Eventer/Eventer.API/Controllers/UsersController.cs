using Eventer.API.Logging;
using Eventer.Data.Exceptions;
using Eventer.Data.Models;
using Eventer.Logic.DTOs;
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

        public UsersController(IRequestLogger<UsersController> logger, UserService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<UserDTO> GetUsers()
        {
            return _service.GetUsers();
        }

        [HttpPost]
        public IActionResult CreateUser(UserDTO userDTO)
        {
            _service.CreateUser(userDTO);
            return Ok();
        }

        [HttpPut]
        public IActionResult EditUser(UserDTO userDTO)
        {
            _service.UpdateUser(userDTO);
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
