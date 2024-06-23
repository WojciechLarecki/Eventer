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
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger, UserService service)
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
        public void CreateUser(UserDTO userDTO)
        {
            _service.CreateUser(userDTO);
        }

        [HttpPut]
        public IActionResult EditUser(UserDTO userDTO)
        {
            try
            {
                _service.UpdateUser(userDTO);
                return Ok();
            }
            catch (NotFoundInDBException)
            {
                return NotFound();
            }
            catch (Exception e)
            {
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
                return BadRequest(e.Message);
            }
        }
    }
}
