using Eventer.Data.Models;
using Eventer.Logic.DTOs;
using Eventer.Logic.DTOs.CreateDTOs;
using Eventer.Logic.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Eventer.Logic
{
    public static class MapHelper
    {
        public static UserDTO ToDTO(this User user)
        {
            return new UserDTO()
            {
                Id = user.Id,
                Email = user.Email,
                Role = user.Role,
                Name = user.Name,
                Surname = user.Surname
            };
        }

        public static IEnumerable<UserDTO> ToDTOs(this IEnumerable<User> users)
        {
            return users.Select(u => ToDTO(u));
        }

        public static User ToEntity(this UserCreateDTO userDTO)
        {
            UserValidator.CheckEmail(userDTO.Email);
            UserValidator.CheckPassword(userDTO.Password);
            UserValidator.CheckRole(userDTO.Role);

            return new User()
            {
                Role = userDTO.Role!.Value,
                Password = userDTO.Password!,
                Email = userDTO.Email!,
                Name = userDTO.Name!,
                Surname = userDTO.Surname!,
            };
        }

        public static EventDTO ToDTO(this Event @event)
        {
            return new EventDTO()
            {
                StartDate = @event.StartDate,
                EndDate = @event.EndDate,
                Name = @event.Name,
                Id = @event.Id,
                JoinDate = @event.JoinDate
            };
        }

        public static IEnumerable<EventDTO> ToDTOs(this IEnumerable<Event> users)
        {
            return users.Select(e => ToDTO(e));
        }
    }
}
