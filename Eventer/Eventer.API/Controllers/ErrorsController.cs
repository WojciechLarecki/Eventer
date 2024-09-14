using Eventer.API.Logging;
using Eventer.Data.Exceptions;
using Eventer.Logic.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Eventer.API.Controllers
{
    public class ErrorsController : Controller
    {
        private readonly IRequestLogger<ErrorsController> _logger;

        public ErrorsController(IRequestLogger<ErrorsController> logger)
        {
            _logger = logger;
        }

        [Route("/error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult HandleErrorDevelopment()
        {
            var exceptionHandlerFeature =
                HttpContext.Features.Get<IExceptionHandlerFeature>()!;

            var error = exceptionHandlerFeature.Error;

            if (error is NotFoundInDBException)
            {
                _logger.LogNotFound(error);
                return NotFound();
            }
            else if (error is WrongInputException)
            {
                _logger.LogBadRequest(error);
                return BadRequest();
            }
            else if (error is ForbiddenOperationException)
            {
                _logger.LogForbid(error);
                return Forbid();
            }
            else
            {
                _logger.LogInternalServerError(error);
                return StatusCode(500);
            }
        }
    }
}
