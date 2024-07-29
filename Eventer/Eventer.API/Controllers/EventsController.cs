using Eventer.Data.Models;
using Eventer.Logic.DTOs;
using Eventer.Logic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Eventer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly EventService _service;
        private readonly ILogger<EventsController> _logger;

        public EventsController(ILogger<EventsController> logger, EventService service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetEvents()
        {
            var dtos = new List<EventDTO>();
            
            try
            {
                dtos = _service.GetEvents().ToList();
            }
            catch
            {
                return StatusCode(500, "Server has a problem with retring data.");
            }

            if (dtos.Count == 0)
            {
                return NoContent();
            }

            return Ok(dtos);
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
