namespace Chushka.Web.Controllers.Account
{
    using Chushka.Models;
    using Chushka.Web.Services.Contracts;
    using Chushka.Web.ViewModels.Account;
    using Microsoft.AspNetCore.Mvc;

    public class AccountController : Controller
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserViewModel model)
        {
            return this.accountService.Login(model);
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserViewModel model)
        {
            return this.accountService.Register(model);
        }

        public IActionResult Logout()
        {
            return accountService.Logout();
        }
    }
}