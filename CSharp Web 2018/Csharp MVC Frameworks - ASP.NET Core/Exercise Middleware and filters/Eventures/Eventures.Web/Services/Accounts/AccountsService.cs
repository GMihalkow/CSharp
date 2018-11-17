namespace Eventures.Web.Services.Accounts
{
    using Eventures.Models;
    using Eventures.Web.Services.Accounts.Contracts;
    using Eventures.Web.Services.DbContext;
    using Eventures.Web.ViewModels.Accounts;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System.Linq;
    using System.Threading.Tasks;

    public class AccountsService : PageModel, IAccountsService
    {
        private readonly DbService dbService;
        private readonly UserManager<EventureUser> userManager;
        private readonly SignInManager<EventureUser> signInManager;

        public AccountsService(DbService dbService, UserManager<EventureUser> userManager, SignInManager<EventureUser> signInManager)
        {
            this.dbService = dbService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Login(RegisterUserViewModel model)
        {
            return this.OnLoginPostAsync(model).Result;
        }

        public IActionResult Register(RegisterUserViewModel model)
        {
            return OnRegisterPostAsync(model).Result;
        }


        public async void Logout()
        {
            await signInManager.SignOutAsync();
        }

        public async Task<IActionResult> OnRegisterPostAsync(RegisterUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new EventureUser { UserName = model.Username, FirstName = model.FirstName, LastName = model.LastName, Email = model.Email };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    if (this.dbService.DbContext.Users.Count() == 1)
                    {
                        await this.userManager.AddToRoleAsync(user, "Admin");
                    }
                    else
                    {
                        await this.userManager.AddToRoleAsync(user, "User");
                    }
                    
                    var code = await userManager.GenerateEmailConfirmationTokenAsync(user);

                    await signInManager.SignInAsync(user, isPersistent: false);
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

        public async Task<IActionResult> OnLoginPostAsync(RegisterUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = this.dbService.DbContext.Users.FirstOrDefault(x => x.UserName == model.Username);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return this.Page();
                }
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                bool RememberMe = model.RememberMe == "RememberMe";
                var result = await signInManager.PasswordSignInAsync(user, model.Password, RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    return this.Redirect("/");
                }
                if (result.IsLockedOut)
                {
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
    }
}