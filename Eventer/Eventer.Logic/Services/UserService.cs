using Eventer.Data.Models;
using Eventer.Data.Repositories;
using Eventer.Logic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventer.Logic.Services
{
    public class UserService
    {
        private readonly IRepositoryManager _repoManager;
        public UserService(IRepositoryManager manager)
        {
            _repoManager = manager;
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            var users = _repoManager.UserRepository.GetAll(false);
            var userDTOs = users.ToDTOs();
            return userDTOs;
        }
    }
}
