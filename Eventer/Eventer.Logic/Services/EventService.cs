using Eventer.Data.Repositories;
using Eventer.Logic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventer.Logic.Services
{
    public class EventService
    {
        private readonly IRepositoryManager _repoManager;
        public EventService(IRepositoryManager manager)
        {
            _repoManager = manager;
        }

        public IEnumerable<EventDTO> GetEvents()
        {
            var events = _repoManager.EventsRepository.GetAll();
            var eventDTOs = events.ToDTOs();

            return eventDTOs;
        }
    }
}
