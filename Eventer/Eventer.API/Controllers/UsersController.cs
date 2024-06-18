using Eventer.Data.Models;
using Eventer.Logic.DTOs;
using Eventer.Logic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IEnumerable<User> CreateUser()
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public IEnumerable<User> EditUser()
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public IEnumerable<User> DeleteUser()
        {
            throw new NotImplementedException();
        }
    }
}
