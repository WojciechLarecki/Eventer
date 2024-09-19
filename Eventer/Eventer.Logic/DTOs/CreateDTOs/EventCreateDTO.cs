using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventer.Logic.DTOs.CreateDTOs
{
    public class EventCreateDTO : IValidatableObject
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime? JoinDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartDate < DateTime.Now)
            {
                yield return new ValidationResult(
                    $"Start date cannot be set earlier the presence.",
                    new[] { nameof(StartDate) });
            }
            if (EndDate <= StartDate)
            {
                yield return new ValidationResult(
                    $"End date cannot be set before or in the same time as start date.",
                    new[] { nameof(EndDate) });
            }
        }
    }
}
