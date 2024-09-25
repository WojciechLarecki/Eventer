using Eventer.API.Logging;
using Eventer.Data.Exceptions;
using Eventer.Data.Models;
using Eventer.Logic.DTOs;
using Eventer.Logic.DTOs.CreateDTOs;
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
        public async Task<IActionResult> GetEventsAsync()
        {
            List<EventDTO> dtos = (await _service.GetEventsAsync()).ToList();
            
            if (dtos.Count == 0)
            {
                _logger.LogNoContent();
                return NoContent();
            }

            return Ok(dtos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEventAsync(EventCreateDTO eventDTO)
        {
            var dto = await _service.CreateEventAsync(eventDTO);

            return Ok(dto);
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
