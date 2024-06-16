using Eventer.Data.Models;
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

        public Event? Find(Guid id)
        {
            return _context.Events.Find(id);
        }
    }
}
