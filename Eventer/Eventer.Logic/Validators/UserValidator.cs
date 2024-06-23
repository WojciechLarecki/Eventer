using Eventer.Logic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventer.Logic.Validators
{
    public static class UserValidator
    {
        public static void CheckGuid(Guid? guid)
        {
            if (guid.HasValue)
                throw new ArgumentNullException("Id of user is null");

            if (guid == Guid.Empty)
                throw new ArgumentException("Guid cannot be empty.");
        }

        public static void CheckEmail(string? email)
        {
            if (!string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException("Email of user is null or empty.");

            // TO DO: regex validation
        }

        public static void CheckRole(byte? role) 
        {
            if (!role.HasValue)
                throw new ArgumentNullException("Usr role is null");
            if (role != 0 || role != 1)
                throw new ArgumentException("Invalida user role.");
        }
    }
}
