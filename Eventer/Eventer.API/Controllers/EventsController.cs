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
        private readonly ILogger<EventsController> _logger;
        private IActionResult InternalServerError() => StatusCode(500, "Server has a problem with retring data.");

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
        public IActionResult CreateEvent(EventDTO eventDTO)
        {
            try
            {
                _service.CreateEvent(eventDTO);
            }
            catch(Exception)
            {
                return StatusCode(500, "Server has a problem with event creation.");
            }

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateEvent(EventDTO eventDTO)
        {
            try
            {
                _service.UpdateEvent(eventDTO);
            }
            catch (NotFoundInDBException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500, "Server has a problem with retring data.");
            } 

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteEvent(Guid eventId)
        {
            try
            {
                _service.DeleteEvent(eventId);
            }
            catch (NotFoundInDBException)
            {
                return NotFound();
            }
            catch(InvalidOperationException)
            {
                return Forbid();
            }
            catch(Exception)
            {
                return InternalServerError();
            }

            return Ok();
        }
    }
}
