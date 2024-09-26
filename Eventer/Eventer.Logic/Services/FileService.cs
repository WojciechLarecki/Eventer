using Eventer.Data.Exceptions;
using Eventer.Data.Repositories;
using Eventer.Logic.Validators;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventer.Logic.Services
{
    public class FileService
    {
        private readonly IRepositoryManager _repoManager;
        public FileService(IRepositoryManager manager)
        {
            _repoManager = manager;
        }

        public async Task<(byte[], string)> GetEventUsersListCSVAsync(Guid eventId)
        {
            var eventDB = await _repoManager.EventsRepository.FindFullAsync(eventId) ?? throw new NotFoundInDBException("Event not found in database.");
            var fileName = GetUserListCSVFileName(eventDB.Name);
            var writer = new CSVWriter();
            
            writer.WriteLine("Email");
            foreach (var user in eventDB.Users)
            {
                writer.WriteLine(user.Email);
            }
            
            var content = Encoding.UTF8.GetBytes(writer.Content);

            return (content, fileName);
        }

        public async Task<(byte[], string)> GetUserEventsListCSVAsync(Guid userId)
        {
            var user = await _repoManager.UserRepository.FindFullAsync(userId) ?? throw new NotFoundInDBException("Event not found in database.");
            var fileName = GetEventsListCSVFileName(user.Email);
            var writer = new CSVWriter();

            writer.WriteLine("Name", "Start date", "End date");
            foreach (var @event in user.Events.ToList())
            {
                writer.WriteLine(@event.Name, @event.StartDate.ToString(), @event.EndDate.ToString());
            }

            var content = Encoding.UTF8.GetBytes(writer.Content);

            return (content, fileName);
        }

        private string GetEventsListCSVFileName(string email)
        {
            var index = email.IndexOf('@');
            if (index == -1)
                throw new ArgumentException("Given email isn't an email.");

            var forbiddenChars = new char[]
            {
                '/', // char that cannot be used inside linux file name 
                '<', '>', ':', '"', '/', '\\', '|', '?', '*' // chars that cannot be used inside widnows file name
            };

            foreach (var @char in forbiddenChars)
            {
                if (email.Contains(@char))
                    throw new ArgumentException($@"Given email contains '{@char}' char which cannot be used inside file name.");
            }

            var userName = email.Substring(0, index);
            var now = DateTime.Now;

            return $"{userName}_Events_{now.ToString("ddMMyyyy_hhmm")}";
        }

        private string GetUserListCSVFileName(string eventName)
        {
            var date = DateTime.Now;
            return $"{eventName}_Users_{date.ToString("ddMMyyyy_hhmm")}";
        }
    }
}
