namespace Eventures.Web.ViewModels.Events
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreateEventInputModel : IValidatableObject
    {
        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Place { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Start { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime End { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int TotalTickets { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(0.00, 9999999999999999.99)]
        public decimal PricePerTicket { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            int result = DateTime.Compare(this.Start, this.End);

            if (result < 0)
            {
                yield return ValidationResult.Success;
            }
            else
            {
                var test = new ValidationResult("Start date must be before the End date.");
                yield return test;
            }
        }
    }
}