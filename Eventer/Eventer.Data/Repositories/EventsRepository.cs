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

        public async Task AddAsync(Event eventToDB)
        {
            await _context.Events.AddAsync(eventToDB);
        }

        public void Delete(Event eventToDelete)
        {
            if (eventToDelete.Users.Count != 0)
            {
                throw new InvalidOperationException("Event is not empty, therefore cannot be deleted.");
            }

            // remove users links to this event
            foreach (var user in eventToDelete.Users)
            {
                user.Events.Remove(eventToDelete);
            }

            _context.Events.Remove(eventToDelete);
        }

        public Event? Find(Guid id)
        {
            return _context.Events.Find(id);
        }

        public async Task<Event?> FindAsync(Guid id)
        {
            return await _context.Events.FindAsync(id);
        }

        public Event? FindFull(Guid id)
        {
            return _context.Events
                .Where(e => e.Id == id)
                .Include(e => e.Users)
                .FirstOrDefault();
        }

        public async Task<Event?> FindFullAsync(Guid id)
        {
            return await _context.Events
                .Where(e => e.Id == id)
                .Include(e => e.Users)
                .FirstOrDefaultAsync();
        }
    }
}
