using Eventer.API.Logging;
using Eventer.Logic.DTOs;
using Eventer.Logic.DTOs.CreateDTOs;
using Eventer.Logic.Services;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> UpdateEventAsync(EventDTO eventDTO)
        {
            await _service.UpdateEventAsync(eventDTO);

            return Ok();
        }

        [HttpDelete("{eventId:Guid}")]
        public async Task<IActionResult> DeleteEventAsync(Guid eventId)
        {
            await _service.DeleteEventAsync(eventId);

            return Ok();
        }
    }
}
