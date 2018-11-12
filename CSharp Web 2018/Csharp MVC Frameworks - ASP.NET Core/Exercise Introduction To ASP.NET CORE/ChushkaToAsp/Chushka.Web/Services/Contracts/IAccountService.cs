namespace Chushka.Web.Services.Contracts
{
    using Chushka.Web.ViewModels.Account;
    using Microsoft.AspNetCore.Mvc;

    public interface IAccountService
    {
        IActionResult Register(RegisterUserViewModel user);

        IActionResult Login(RegisterUserViewModel model);

        IActionResult Logout();
    }
}