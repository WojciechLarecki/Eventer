using Eventer.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eventer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CSVController : ControllerBase
    {
        private readonly EventerContext _context;
        private readonly ILogger<CSVController> _logger;

        public CSVController(ILogger<CSVController> logger, EventerContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetUsersListCSV()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult GetEventsListCSV()
        {
            throw new NotImplementedException();
        }
    }
}
