﻿using System.ComponentModel.DataAnnotations;

namespace Eventer.Logic.DTOs.CreateDTOs
{
    public class EventCreateDTO : IValidatableObject
    {
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? StartDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? EndDate { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? JoinDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartDate < DateTime.Now)
            {
                yield return new ValidationResult(
                    $"Start date cannot be set in the past.",
                    new[] { nameof(StartDate) });
            }
            if (EndDate <= StartDate)
            {
                yield return new ValidationResult(
                    $"End date cannot be set before or in the same time as start date.",
                    new[] { nameof(EndDate) });
            }
            if (JoinDate > EndDate || JoinDate <= StartDate)
            {
                yield return new ValidationResult(
                    $"Join date must be set between start date and end date.",
                    new[] { nameof(JoinDate) });
            }
        }
    }
}
