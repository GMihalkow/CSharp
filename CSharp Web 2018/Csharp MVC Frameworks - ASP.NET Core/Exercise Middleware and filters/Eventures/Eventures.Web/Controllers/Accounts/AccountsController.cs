namespace Eventures.Web.Controllers.Accounts
{
    using AutoMapper;
    using Eventures.Models;
    using Eventures.Services.Accounts.Contracts;
    using Eventures.Web.ViewModels.Accounts;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class AccountsController : BaseController
    {
        private readonly IMapper mapper;
        private readonly IAccountService accountsService;
        private readonly SignInManager<EventureUser> signInManager;

        public AccountsController(IMapper mapper, IAccountService accountsService, SignInManager<EventureUser> signInManager)
        {
            this.mapper = mapper;
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
            var user = this.mapper.Map<EventureUser>(model);

            if (ModelState.IsValid)
            {
                var result = this.accountsService.Login(user, model.Password);

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
            var user = this.mapper.Map<EventureUser>(model);

            if (ModelState.IsValid)
            {
                var result = this.accountsService.Register(user, model.Password);

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