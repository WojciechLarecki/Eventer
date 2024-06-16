using Eventer.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eventer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly EventerContext _context;
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger, EventerContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Event> GetUsers()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IEnumerable<Event> CreateUser()
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public IEnumerable<Event> EditUser()
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public IEnumerable<Event> DeleteUser()
        {
            throw new NotImplementedException();
        }
    }
}
