using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventer.Logic.DTOs.CreateDTOs
{
    public class UserCreateDTO
    {

        [Required]
        [EmailAddress] // checks if string contains '@' sign.
        [MaxLength(50)]
        public string? Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Surname { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Password { get; set; }

        [Required]
        [Range(0, 1)]
        public byte? Role { get; set; }
    }
}
