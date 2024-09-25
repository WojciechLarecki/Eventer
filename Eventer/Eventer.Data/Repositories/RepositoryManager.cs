using Eventer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventer.Data.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly EventerContext _context;
        private readonly Lazy<UserRepository> _userRepo;
        private readonly Lazy<EventsRepository> _eventsRepo;
        public RepositoryManager(EventerContext context)
        {
            _context = context;
            _userRepo = new Lazy<UserRepository>(() => new UserRepository(context));
            _eventsRepo = new Lazy<EventsRepository>(() => new EventsRepository(context));
        }

        public UserRepository UserRepository => _userRepo.Value;
        public EventsRepository EventsRepository => _eventsRepo.Value;
        public void Save() => _context.SaveChanges();
        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}
