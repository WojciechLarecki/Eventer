﻿using Eventer.Data.Exceptions;
using Eventer.Data.Models;
using Eventer.Data.Repositories;
using Eventer.Logic.DTOs;
using Eventer.Logic.Validators;
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

        public void CreateEvent(EventDTO eventDTO)
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

            _repoManager.EventsRepository.Add(eventToDB);
            _repoManager.Save();
        }

        public void DeleteEvent(Guid eventId)
        {
            var eventToDelete = _repoManager.EventsRepository.FindFull(eventId);

            if (eventToDelete == null)
            {
                throw new NotFoundInDBException("Event has not been found in database.");
            }

            _repoManager.EventsRepository.Delete(eventToDelete);
        }

        public IEnumerable<EventDTO> GetEvents()
        {
            var events = _repoManager.EventsRepository.GetAll();
            var eventDTOs = events.ToDTOs();

            return eventDTOs;
        }

        public void UpdateEvent(EventDTO eventDTO)
        {
            if (eventDTO.Id == null)
            {
                throw new ArgumentException("Event must have an id.");
            }

            var dbEvent = _repoManager.EventsRepository.Find(eventDTO.Id.Value);

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

            _repoManager.Save();
        }
    }
}
