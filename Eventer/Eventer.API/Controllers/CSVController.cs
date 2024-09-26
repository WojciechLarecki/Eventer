using Eventer.API.Logging;
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

        public CSVController(FileService service)
        {
            _service = service;
        }

        [HttpGet("Events/{eventId:Guid}/Users/listCSV")]
        public async Task<IActionResult> GetEventUsersListCSVAsync(Guid eventId)
        {
            FileContentResult file;
            byte[] content;
            string fileName;

            (content, fileName) = await _service.GetEventUsersListCSVAsync(eventId);

            file = new FileContentResult(content, "text/csv");
            file.FileDownloadName = fileName;

            return file;
        }

        [HttpGet("Users/{userId:Guid}/Events/listCSV")]
        public async Task<IActionResult> GetUserEventsListCSVAsync(Guid userId)
        {
            FileContentResult file;
            byte[] content;
            string fileName;

            (content, fileName) = await _service.GetUserEventsListCSVAsync(userId);

            file = new FileContentResult(content, "text/csv");
            file.FileDownloadName = fileName;

            return file;
        }
    }
}
