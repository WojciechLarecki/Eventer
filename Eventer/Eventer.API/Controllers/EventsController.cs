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
        private IActionResult InternalServerError() => StatusCode(500, "Server has a problem with retring data.");

        public EventsController(IRequestLogger<EventsController> logger, EventService service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetEvents()
        {
            List<EventDTO> dtos;

            try
            {
                dtos = _service.GetEvents().ToList();
            }
            catch (Exception e)
            {
                _logger.LogInternalServerError(e);
                return InternalServerError();
            }

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
            try
            {
                _service.CreateEvent(eventDTO);
            }
            catch (NotFoundInDBException e)
            {
                _logger.LogNotFound(e);
                return NotFound();
            }
            catch (ArgumentException e)
            {
                _logger.LogBadRequest(e);
                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogInternalServerError(e);
                return InternalServerError();
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
            catch (NotFoundInDBException e)
            {
                _logger.LogNotFound(e);
                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogInternalServerError(e);
                return InternalServerError();
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
            catch (NotFoundInDBException e)
            {
                _logger.LogNotFound(e);
                return NotFound();
            }
            catch (InvalidOperationException e)
            {
                _logger.LogForbid(e);
                return Forbid();
            }
            catch (Exception e)
            {
                _logger.LogInternalServerError(e);
                return InternalServerError();
            }

            return Ok();
        }
    }
}
