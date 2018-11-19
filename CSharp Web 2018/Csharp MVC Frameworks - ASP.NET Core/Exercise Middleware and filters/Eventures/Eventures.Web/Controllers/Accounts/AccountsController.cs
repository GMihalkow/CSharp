﻿namespace Eventures.Web.Controllers.Accounts
{
    using Eventures.Web.Models;
    using Eventures.Web.Services.Accounts.Contracts;
    using Eventures.Web.ViewModels.Accounts;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class AccountsController : BaseController
    {
        private readonly IAccountService accountsService;

        public AccountsController(IAccountService accountsService)
        {
            this.accountsService = accountsService;
        }

        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserInputModel model)
        {
            if(ModelState.IsValid)
            {
                var result = this.accountsService.Login(model);

                if (result is PageResult)
                {
                    result = this.View("Error", new ErrorViewModel { ErrorMessage = "Invalid login attempt." });
                }

                return result;
            }
            else
            {
                return this.View(model);
            }
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserViewModel model)
        {
            var result = this.accountsService.Register(model);

            return result;
        }

        public IActionResult Logout()
        {
            return this.accountsService.Logout().Result;
        }
    }
}