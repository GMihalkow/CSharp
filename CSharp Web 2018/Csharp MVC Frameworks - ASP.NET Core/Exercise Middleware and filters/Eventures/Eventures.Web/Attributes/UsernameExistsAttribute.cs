﻿namespace Eventures.Web.Attributes
{
    using Eventures.Web.Services.DbContext;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    [AttributeUsage(AttributeTargets.Property)]
    public class UsernameExistsAttribute : ValidationAttribute
    {
        private DbService dbService;

        public UsernameExistsAttribute()
        {

        }

        public UsernameExistsAttribute(string errorMessage) : base(errorMessage)
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            this.dbService = (DbService)validationContext
                .GetService(typeof(DbService));

            if (!(this.dbService.DbContext.Users.Any(u => u.UserName == value.ToString())))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Username already exists.");
            }
        }
    }
}