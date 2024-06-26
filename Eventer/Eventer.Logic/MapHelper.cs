﻿using Eventer.Data.Models;
using Eventer.Logic.DTOs;
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
            return new UserDTO();
        }

        public static IEnumerable<UserDTO> ToDTOs(this IEnumerable<User> users)
        {
            return users.Select(u => ToDTO(u));
        }
    }
}
