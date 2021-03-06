﻿namespace Forum.Web.Attributes
{
    using Eventures.Services.Accounts.Contracts;
    using Eventures.Web.ViewModels.Accounts;
    using System;
    using System.ComponentModel.DataAnnotations;

    [AttributeUsage(AttributeTargets.Class)]
    public class UserExistsAttribute : ValidationAttribute
    {
        private IAccountService accountService;

        public UserExistsAttribute(string errorMessage) : base(errorMessage)
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            this.accountService = (IAccountService)validationContext
                .GetService(typeof(IAccountService));

            var model = (LoginUserInputModel)validationContext.ObjectInstance;

            if (!(this.accountService.UserWithPasswordExists(model.Username, model.Password)).GetAwaiter().GetResult())
            {
                return new ValidationResult("Invalid login attempt.");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}