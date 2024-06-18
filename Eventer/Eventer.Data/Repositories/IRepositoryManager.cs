namespace Eventer.Data.Repositories
{
    public interface IRepositoryManager
    {
        EventsRepository EventsRepository { get; }
        UserRepository UserRepository { get; }

        void Save();
    }
}