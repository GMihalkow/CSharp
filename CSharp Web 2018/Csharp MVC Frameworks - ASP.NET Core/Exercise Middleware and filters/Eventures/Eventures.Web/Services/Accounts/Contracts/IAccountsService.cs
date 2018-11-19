﻿namespace Eventures.Web.Services.Accounts.Contracts
{
    using Eventures.Web.ViewModels.Accounts;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public interface IAccountService
    {
        IActionResult Register(RegisterUserViewModel model);

        IActionResult Login(LoginUserInputModel model);

        Task<IActionResult> Logout();
    }
}