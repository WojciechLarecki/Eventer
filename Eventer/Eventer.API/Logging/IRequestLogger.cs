namespace Eventer.API.Logging
{
    public interface IRequestLogger<T>
    {
        void LogBadRequest(Exception e);
        void LogNotFound(Exception e);
        void LogInternalServerError(Exception e);
    }
}
