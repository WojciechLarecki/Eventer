using Eventer.Data.Exceptions;
using Eventer.Data.Models;
using Eventer.Logic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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
            byte[] content;
            string fileName;
            try
            {
                (content, fileName) = _service.GetEventUsersListCSV(eventId);

                file = new FileContentResult(content, "text/csv");
                file.FileDownloadName = fileName;
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

        [HttpGet("User/{userId:Guid}/Events/listCSV")]
        public IActionResult GetUserEventsListCSV(Guid userId)
        {
            FileContentResult file;
            byte[] content;
            string fileName;
            try
            {
                (content, fileName) = _service.GetUserEventsListCSV(userId);

                file = new FileContentResult(content, "text/csv");
                file.FileDownloadName = fileName;
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
    }
}
