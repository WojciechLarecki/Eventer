using Eventer.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eventer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly EventerContext _context;
        private readonly ILogger<EventsController> _logger;

        public EventsController(ILogger<EventsController> logger, EventerContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Event> GetEvents()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IEnumerable<Event> CreateEvent()
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public IEnumerable<Event> EditEvent()
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public IEnumerable<Event> DeleteEvent()
        {
            throw new NotImplementedException();
        }
    }
}
