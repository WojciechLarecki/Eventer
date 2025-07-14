using Eventer.Data.Exceptions;
using Eventer.Data.Models;
using Eventer.Data.Repositories;
using Eventer.Logic.DTOs;
using Eventer.Logic.DTOs.CreateDTOs;
using Eventer.Logic.Validators;

namespace Eventer.Logic.Services
{
    public class EventService
    {
        private readonly IRepositoryManager _repoManager;
        public EventService(IRepositoryManager manager)
        {
            _repoManager = manager;
        }

        public async Task<EventDTO> CreateEventAsync(EventCreateDTO eventDTO)
        {
            CommonValidator.CheckIfNotNull(eventDTO.StartDate);
            CommonValidator.CheckIfNotNull(eventDTO.EndDate);
            CommonValidator.CheckIfNotNull(eventDTO.Name);
            CommonValidator.CheckIfProperDateSpan(eventDTO.StartDate!.Value, eventDTO.EndDate!.Value);
            
            var eventToDB = new Event()
            {
                JoinDate = eventDTO.JoinDate,
                Name = eventDTO.Name!,
                StartDate = eventDTO.StartDate!.Value,
                EndDate = eventDTO.EndDate!.Value
            };
            
            await _repoManager.EventsRepository.AddAsync(eventToDB);
            await _repoManager.SaveAsync();

            return eventToDB.ToDTO();
        }

        public async Task DeleteEventAsync(Guid eventId)
        {
            var eventToDelete = await _repoManager.EventsRepository.FindFullAsync(eventId);

            if (eventToDelete == null)
            {
                throw new NotFoundInDBException("Event has not been found in database.");
            }

            _repoManager.EventsRepository.Delete(eventToDelete);

            await _repoManager.SaveAsync();
        }

        public async Task<IEnumerable<EventDTO>> GetEventsAsync()
        {
            var events = await _repoManager.EventsRepository.GetAllAsync();
            var eventDTOs = events.ToDTOs();

            return eventDTOs;
        }

        public async Task UpdateEventAsync(EventDTO eventDTO)
        {
            if (eventDTO.Id == null)
            {
                throw new ArgumentException("Event must have an id.");
            }

            var dbEvent = await _repoManager.EventsRepository.FindAsync(eventDTO.Id.Value);

            if (dbEvent == null)
            {
                throw new NotFoundInDBException("Event has not been found in database.");
            }

            CommonValidator.CheckIfNotNull(eventDTO.StartDate);
            CommonValidator.CheckIfNotNull(eventDTO.EndDate);
            CommonValidator.CheckIfNotNull(eventDTO.Name);

            dbEvent.StartDate = eventDTO.StartDate!.Value;
            dbEvent.EndDate = eventDTO.EndDate!.Value;
            dbEvent.Name = eventDTO.Name!;
            dbEvent.JoinDate = eventDTO.JoinDate;

            await _repoManager.SaveAsync();
        }
    }
}
