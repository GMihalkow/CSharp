namespace Chushka.Web.Services.Contracts
{
    using Chushka.Models;
    using Chushka.Web.ViewModels.Account;
    using Microsoft.AspNetCore.Mvc;

    public interface IAccountService
    {
        IActionResult Register(RegisterUserViewModel user);

        IActionResult Login(LoginUserViewModel model);

        IActionResult Logout();

        ChushkaUser GetUser(string username);
    }
}