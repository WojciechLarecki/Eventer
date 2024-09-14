using Eventer.API.Logging;
using Eventer.Data.Exceptions;
using Eventer.Data.Models;
using Eventer.Logic.DTOs;
using Eventer.Logic.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Reflection.Metadata;

namespace Eventer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly EventService _service;
        private readonly IRequestLogger<EventsController> _logger;

        public EventsController(IRequestLogger<EventsController> logger, EventService service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetEvents()
        {
            List<EventDTO> dtos = _service.GetEvents().ToList();

            if (dtos.Count == 0)
            {
                _logger.LogNoContent();
                return NoContent();
            }

            return Ok(dtos);
        }

        [HttpPost]
        public IActionResult CreateEvent(EventDTO eventDTO)
        {
            _service.CreateEvent(eventDTO);

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateEvent(EventDTO eventDTO)
        {
            _service.UpdateEvent(eventDTO);

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteEvent(Guid eventId)
        {
            _service.DeleteEvent(eventId);

            return Ok();
        }
    }
}
