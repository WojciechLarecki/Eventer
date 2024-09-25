using Eventer.Data.Exceptions;
using Eventer.Data.Models;
using Eventer.Data.Repositories;
using Eventer.Logic.DTOs;
using Eventer.Logic.DTOs.CreateDTOs;
using Eventer.Logic.Validators;
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

        public void AddUserToEvent(Guid eventId, Guid userId)
        {
            var eventFromDB = _repoManager.EventsRepository.FindFull(eventId);
            CommonValidator.CheckIfNotNull(eventFromDB);   
            
            var userFromDB = _repoManager.UserRepository.Find(userId);
            CommonValidator.CheckIfNotNull(userFromDB);
            
            eventFromDB!.Users.Add(userFromDB!);

            _repoManager.Save();
        }

        public void DeleteUserFromEvent(Guid eventId, Guid userId)
        {
            var eventFromDB = _repoManager.EventsRepository.FindFull(eventId);
            CommonValidator.CheckIfNotNull(eventFromDB);

            var userFromDB = _repoManager.UserRepository.Find(userId);
            CommonValidator.CheckIfNotNull(userFromDB);

            eventFromDB!.Users.Remove(userFromDB!);

            _repoManager.Save();
        }

        public void CreateUser(UserCreateDTO userDTO)
        {
            UserValidator.CheckEmail(userDTO.Email);
            UserValidator.CheckPassword(userDTO.Password);
            UserValidator.CheckRole(userDTO.Role);
            
            var user = userDTO.ToEntity();
            
            _repoManager.UserRepository.Add(user);
            _repoManager.Save();
        }

        public void DeleteUser(Guid guid)
        {
            _repoManager.UserRepository.Delete(guid);
        }

        public async Task<IEnumerable<UserDTO>> GetUsersAsync()
        {
            var users = await _repoManager.UserRepository.GetAllAsync();
            var userDTOs = users.ToDTOs();
            return userDTOs;
        }

        public void UpdateUser(UserDTO userDTO)
        {
            UserValidator.CheckGuid(userDTO.Id);
            UserValidator.CheckEmail(userDTO.Email);
            UserValidator.CheckRole(userDTO.Role);

            var user = _repoManager.UserRepository.Find(userDTO.Id!.Value);

            if (user == null)
                throw new NotFoundInDBException("User not found in database.");

            user.Email = userDTO.Email!;
            user.Role = userDTO.Role!.Value;
            _repoManager.Save();
        }
    }
}
