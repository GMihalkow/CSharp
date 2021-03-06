﻿namespace Eventures.Web.Attributes
{
    using Eventures.Services.Accounts.Contracts;
    using System;
    using System.ComponentModel.DataAnnotations;

    [AttributeUsage(AttributeTargets.Property)]
    public class EmailExistsAttribute : ValidationAttribute
    {
        private IAccountService accountService;

        public EmailExistsAttribute()
        {

        }

        public EmailExistsAttribute(string errorMessage) : base(errorMessage)
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            this.accountService = (IAccountService)validationContext
                .GetService(typeof(IAccountService));

            if (this.accountService.EmailExists(value.ToString()).GetAwaiter().GetResult())
            {
                return new ValidationResult("Email already exists.");
            }

            return ValidationResult.Success;
        }
    }
}
