namespace Chushka.Web.Services
{
    using Chushka.Models;
    using Chushka.Web.Data;
    using Chushka.Web.Services.Contracts;
    using Chushka.Web.ViewModels.Account;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Linq;
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;

    public class AccountService : PageModel, IAccountService
    {
        private readonly ChushkaDbContext dbContext;
        private readonly UserManager<ChushkaUser> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly SignInManager<ChushkaUser> _signInManager;
        private readonly ILogger<RegisterUserViewModel> _logger;

        public AccountService(ChushkaDbContext dbContext, UserManager<ChushkaUser> userManager, IEmailSender emailSender, ILogger<RegisterUserViewModel> _logger, SignInManager<ChushkaUser> signInManager)
        {
            this.dbContext = dbContext;
            this._userManager = userManager;
            this._emailSender = emailSender;
            this._signInManager = signInManager;
            this._logger = _logger;
        }

        public IActionResult Login(LoginUserViewModel model)
        {
            return OnLoginPostAsync(model).Result;
        }

        public IActionResult Register(RegisterUserViewModel user)
        {
            return OnRegisterPostAsync(user).Result;
        }

        public IActionResult Logout()
        {
            return this.OnLogoutGetAsync().Result;
        }

        public async Task<IActionResult> OnRegisterPostAsync(RegisterUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ChushkaUser { UserName = model.Username, FullName = model.FullName, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    if (this.dbContext.Users.Count() == 1)
                    {
                        await this._userManager.AddToRoleAsync(user, "Admin");
                    }
                    else
                    {
                        await this._userManager.AddToRoleAsync(user, "User");
                    }

                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return this.Redirect("/");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        public async Task<IActionResult> OnLoginPostAsync(LoginUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = this.dbContext.Users.FirstOrDefault(x => x.UserName == model.Username);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return this.Page();
                }
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return this.Redirect("/");
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return this.Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return this.Page();
        }

        public async Task<IActionResult> OnLogoutGetAsync()
        {
            await _signInManager.SignOutAsync();

            return this.Redirect("/");
        }

        public ChushkaUser GetUser(string username)
        {
            ChushkaUser user = this.dbContext.Users.FirstOrDefault(x => x.UserName == username);
            return user;
        }
    }
}