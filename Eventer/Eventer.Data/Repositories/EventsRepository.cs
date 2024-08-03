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

        public void Delete(Guid eventId)
        {
            _context.Events.Remove(h)
            throw new NotImplementedException();
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
