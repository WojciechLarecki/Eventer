using Eventer.Data.Repositories;
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

        public byte[] GetEventUsersListCSV(Guid eventId)
        {
            throw new NotImplementedException();
        }
    }
}
