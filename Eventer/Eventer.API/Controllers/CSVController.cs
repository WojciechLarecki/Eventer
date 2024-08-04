using Eventer.Data.Exceptions;
using Eventer.Data.Models;
using Eventer.Logic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eventer.API.Controllers
{
    [ApiController]
    public class CSVController : ControllerBase
    {
        private readonly FileService _service;
        private readonly ILogger<CSVController> _logger;

        public CSVController(ILogger<CSVController> logger, FileService service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("Event/{eventId:Guid}/Users/listCSV")]
        public IActionResult GetEventUsersListCSV(Guid eventId)
        {
            FileContentResult file;
            try
            {
                var content = _service.GetEventUsersListCSV(eventId);
                file = new FileContentResult(content, "text/csv");
            }
            catch (NotFoundInDBException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
            return file;
        }

        [HttpGet]
        public IActionResult GetEventsListCSV()
        {
            throw new NotImplementedException();
        }
    }
}
