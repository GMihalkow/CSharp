namespace Chushka.Web.Controllers.Account
{
    using Chushka.Models;
    using Chushka.Web.Models;
    using Chushka.Web.Services.Contracts;
    using Chushka.Web.ViewModels.Account;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

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
            var result = this.accountService.Login(model);
            if(result is PageResult)
            {
                result = this.View("_TestError", new ErrorViewModel { Description = "Invalid login attempt" });
            }

            return result;
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserViewModel model)
        {
            var result = this.accountService.Register(model);
            if (result is PageResult)
            {
                result = this.View("_TestError", new ErrorViewModel { Description = "Invalid registration attempt" });
            }

            return result;
        }

        public IActionResult Logout()
        {
            return accountService.Logout();
        }
    }
}