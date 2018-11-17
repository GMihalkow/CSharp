namespace Eventures.Web.Services.Accounts.Contracts
{
    using Eventures.Web.ViewModels.Accounts;
    using Microsoft.AspNetCore.Mvc;

    public interface IAccountsService
    {
        IActionResult Register(RegisterUserViewModel model);

        IActionResult Login(RegisterUserViewModel model);

        void Logout();
    }
}