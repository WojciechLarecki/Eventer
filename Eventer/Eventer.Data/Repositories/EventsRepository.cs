using Eventer.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventer.Data.Repositories
{
    public class EventsRepository : Repository<Event>
    {
        public EventsRepository(EventerContext context) : base(context)
        {
        }

        public void Add(Event eventToDB)
        {
            _context.Events.Add(eventToDB);
        }

        public void Delete(Event eventToDelete)
        {
            if (eventToDelete.Users.Count != 0)
            {
                throw new InvalidOperationException("Event is not empty, therefore cannot be deleted.");
            }
            
            _context.Events.Remove(eventToDelete);
        }

        public Event? Find(Guid id)
        {
            return _context.Events.Find(id);
        }

        public Event? FindFull(Guid id)
        {
            return _context.Events
                .Where(e => e.Id == id)
                .Include(e => e.Users)
                .FirstOrDefault();
        }
    }
}
