
namespace Eventer.API.Logging
{
    public class RequestLogger<T> : IRequestLogger<T>
    {
        private readonly ILogger<T> _logger;
        public RequestLogger(ILogger<T> logger)
        {
            _logger = logger;
        }

        public void LogBadRequest(Exception e)
        {
            _logger.LogWarning(e, "App returns code {code} - Bad request", 400);
        }

        public void LogNotFound(Exception e)
        {
            _logger.LogWarning(e, "App returns code {code} - Not found", 404);
        }

        public void LogInternalServerError(Exception e)
        {
            _logger.LogError(e, "App returns code {code} - Internal server error", 500);
        }

        public void LogNoContent()
        {
            _logger.LogInformation("App returns code {code} - No content", 204);
        }

        public void LogForbid(Exception e)
        {
            _logger.LogWarning("App returns code {code} - Forbidded", 403);
        }
    }
}
