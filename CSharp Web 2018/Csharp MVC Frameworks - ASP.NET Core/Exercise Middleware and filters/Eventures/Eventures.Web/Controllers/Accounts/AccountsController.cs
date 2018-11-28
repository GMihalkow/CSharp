namespace Eventures.Web.Controllers.Accounts
{
    using Eventures.Models;
    using Eventures.Web.Services.Accounts.Contracts;
    using Eventures.Web.ViewModels.Accounts;
    using Microsoft.AspNetCore.Authentication.Facebook;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Threading.Tasks;

    public class AccountsController : BaseController
    {
        private readonly IAccountService accountsService;
        private readonly SignInManager<EventureUser> signInManager;

        public AccountsController(IAccountService accountsService, SignInManager<EventureUser> signInManager)
        {
            this.accountsService = accountsService;
            this.signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserInputModel model)
        {
            if (ModelState.IsValid)
            {
                var result = this.accountsService.Login(model);

                if (result == true)
                {
                    return this.Redirect("/");
                }
                else
                {
                    return this.View(model);
                }
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
            if (ModelState.IsValid)
            {
                var result = this.accountsService.Register(model);

                if (result == true)
                {
                    return this.Redirect("/");
                }
                else
                {
                    return this.View(model);
                }
            }
            else
            {
                return this.View(model);
            }
        }

        public IActionResult Logout()
        {
            this.accountsService.Logout();
            return this.Redirect("/");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            // Request a redirect to the external login provider.
            var redirectUrl = Url.RouteUrl("SigninFacebook", new { returnUrl });
            var properties = signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

            var test = this.Request;

            var result = this.Challenge(properties, provider);
            return result;
        }

        [HttpGet("signin-facebook", Name = "SigninFacebook")]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            await this.accountsService.ExternalLogin();

            return this.Redirect("/");
        }
    }
}