using Eventer.Data.Exceptions;
using Eventer.Data.Repositories;
using Eventer.Logic.Validators;
using System;
using System.Collections.Generic;
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

        public (byte[], string) GetEventUsersListCSV(Guid eventId)
        {
            var eventDB = _repoManager.EventsRepository.FindFull(eventId) ?? throw new NotFoundInDBException("Event not found in database.");
            var fileName = GetUserListCSVFileName(eventDB.Name);
            var writer = new CSVWriter();
            
            writer.WriteLine("Email");
            foreach (var user in eventDB.Users.ToList())
            {
                writer.WriteLine(user.Email);
            }
            
            var content = Encoding.UTF8.GetBytes(writer.Content);

            return (content, fileName);
        }

        public (byte[] content, string fileName) GetUserEventsListCSV(Guid userId)
        {
            throw new NotImplementedException();
        }

        private string GetUserListCSVFileName(string eventName)
        {
            var date = DateTime.Now;
            return $"{eventName}_Users_{date.ToString("ddMMyyyy_hhmm")}";
        }
    }
}
