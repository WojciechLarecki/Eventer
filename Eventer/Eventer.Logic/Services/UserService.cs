using Eventer.Data.Exceptions;
using Eventer.Data.Models;
using Eventer.Data.Repositories;
using Eventer.Logic.DTOs;
using Eventer.Logic.DTOs.CreateDTOs;
using Eventer.Logic.Validators;
using Microsoft.EntityFrameworkCore;
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

        public async Task AddUserToEventAsync(Guid eventId, Guid userId)
        {
            var eventFromDB = await _repoManager.EventsRepository.FindFullAsync(eventId);
            CommonValidator.CheckIfNotNull(eventFromDB);   
            
            var userFromDB = await _repoManager.UserRepository.FindAsync(userId);
            CommonValidator.CheckIfNotNull(userFromDB);
            
            eventFromDB!.Users.Add(userFromDB!);

            await _repoManager.SaveAsync();
        }

        public async Task DeleteUserFromEventAsync(Guid eventId, Guid userId)
        {
            var eventFromDB = await _repoManager.EventsRepository.FindFullAsync(eventId);
            CommonValidator.CheckIfNotNull(eventFromDB);

            var userFromDB = await _repoManager.UserRepository.FindAsync(userId);
            CommonValidator.CheckIfNotNull(userFromDB);

            eventFromDB!.Users.Remove(userFromDB!);

            await _repoManager.SaveAsync();
        }

        public async Task<UserDTO> CreateUserAsync(UserCreateDTO userDTO)
        {
            UserValidator.CheckEmail(userDTO.Email);
            UserValidator.CheckPassword(userDTO.Password);
            UserValidator.CheckRole(userDTO.Role);
            
            var user = userDTO.ToEntity();
            
            await _repoManager.UserRepository.AddAsync(user);
            await _repoManager.SaveAsync();

            return user.ToDTO();
        }

        public async Task DeleteUserAsync(Guid guid)
        {
            var user = await _repoManager.UserRepository.FindAsync(guid);

            if (user == null)
            {
                throw new NotFoundInDBException(nameof(User), guid);
            }

            _repoManager.UserRepository.Delete(user);

            await _repoManager.SaveAsync();
        }

        public async Task<IEnumerable<UserDTO>> GetUsersAsync()
        {
            var users = await _repoManager.UserRepository.GetAllAsync();
            var userDTOs = users.ToDTOs();
            return userDTOs;
        }

        public async Task UpdateUserAsync(UserDTO userDTO)
        {
            UserValidator.CheckGuid(userDTO.Id);
            UserValidator.CheckEmail(userDTO.Email);
            UserValidator.CheckRole(userDTO.Role);

            var user = await _repoManager.UserRepository.FindAsync(userDTO.Id!.Value);

            if (user == null)
                throw new NotFoundInDBException("User not found in database.");

            user.Email = userDTO.Email!;
            user.Role = userDTO.Role!.Value;
            
            await _repoManager.SaveAsync();
        }

        public async Task<UserDTO> GetUser(Guid id)
        {
            UserValidator.CheckGuid(id);

            var user = await _repoManager.UserRepository.GetOneAsync();

            if (user == null)
                throw new NotFoundInDBException("User not found in database");

            return user.ToDTO();
        }
    }
}
