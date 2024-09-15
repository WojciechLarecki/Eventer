using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventer.Logic.DTOs.CreateDTOs
{
    public class UserCreateDTO
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public byte? Role { get; set; }
    }
}
