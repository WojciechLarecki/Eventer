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
        private readonly IRequestLogger<UsersController> _logger;
        private IActionResult InternalServerError(string? message = null) => message == null ? StatusCode(500) : StatusCode(500, message);

        public UsersController(IRequestLogger<UsersController> logger, UserService service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<UserDTO> GetUsers()
        {
            return _service.GetUsers();
        }

        [HttpPost]
        public IActionResult CreateUser(UserDTO userDTO)
        {
            try
            {
                _service.CreateUser(userDTO);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogBadRequest(e);
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult EditUser(UserDTO userDTO)
        {
            try
            {
                _service.UpdateUser(userDTO);
                return Ok();
            }
            catch (NotFoundInDBException e)
            {
                _logger.LogNotFound(e);
                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogBadRequest(e);
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:Guid}")]
        public IActionResult DeleteUser(Guid id)
        {
            try
            {
                _service.DeleteUser(id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogBadRequest(e);
                return BadRequest(e.Message);
            }
        }

        [HttpPost("/Events/{eventId:Guid}/Users/{userId:Guid}")]
        public IActionResult AddUserToEvent(Guid eventId, Guid userId)
        {
            try
            {
                _service.AddUserToEvent(eventId, userId);
            }
            catch(ArgumentException e)
            {
                _logger.LogBadRequest(e);
                return BadRequest();
            }
            catch(Exception e)
            {
                _logger.LogInternalServerError(e);
                return InternalServerError();
            }

            return Ok();
        }

        [HttpDelete("/Events/{eventId:Guid}/Users/{userId:Guid}")]
        public IActionResult DeleteUserFromEvent(Guid eventId, Guid userId)
        {
            try
            {
                _service.DeleteUserFromEvent(eventId, userId);
            }
            catch (ArgumentException e)
            {
                _logger.LogBadRequest(e);
                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogInternalServerError(e);
                return InternalServerError();
            }

            return Ok();
        }
    }
}
