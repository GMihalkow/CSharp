﻿namespace Eventures.Web.ViewModels.Accounts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class RegisterUserViewModel : IValidatableObject
    {
        [Required]
        [StringLength(50, ErrorMessage = "{0} must be between {2} and {1} characters long.", MinimumLength = 5)]
        public string Username { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "{0} must be between 5 and 50 characters long.", MinimumLength = 5)]
        public string Email { get; set; }

        [Required]
        [Compare("ConfirmPassword", ErrorMessage = "Passwords do not match.")]
        [StringLength(50, ErrorMessage = "{0} must be between 5 and 50 characters long.", MinimumLength = 5)]
        public string Password { get; set; }
        
        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [StringLength(50, ErrorMessage = "{0} must be between {2} and {1} characters long.", MinimumLength = 5)]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "{0} must be between {2} and {1} characters long.", MinimumLength = 5)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "{0} must be between {2} and {1} characters long.", MinimumLength = 5)]
        public string LastName { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "{0} must be between {2} and {1} characters long.", MinimumLength = 5)]
        public string UCN { get; set; }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(this.Password == this.ConfirmPassword)
            {
                yield return ValidationResult.Success;
            }
        }
    }
}