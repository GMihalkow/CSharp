namespace Eventures.Web.Services.Accounts
{
    using Eventures.Models;
    using Eventures.Web.Services.Accounts.Contracts;
    using Eventures.Web.Services.DbContext;
    using Eventures.Web.ViewModels.Accounts;
    using Microsoft.AspNetCore.Identity;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

    public class AccountsService : IAccountService
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


        public async Task<bool> EmailExists(string email)
        {
            EventureUser user = await this.userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool UserExists(string username)
        {
            var result = this.dbService.DbContext.Users.Any(u => u.UserName == username);

            return result;
        }

        public async Task<bool> UserWithPasswordExists(string username, string password)
        {
            if (!this.UserExists(username))
            {
                return false;
            }

            var User = this.dbService.DbContext.Users.First(u => u.UserName == username);

            var result = await this.signInManager.PasswordSignInAsync(User, password, false, false);
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Login(LoginUserInputModel model)
        {
            var result = this.OnLoginPostAsync(model).Result;
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Register(RegisterUserViewModel model)
        {
            var result = OnRegisterPostAsync(model).Result;

            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> OnRegisterPostAsync(RegisterUserViewModel model)
        {
            var user = new EventureUser { UserName = model.Username, FirstName = model.FirstName, UCN = model.UCN, LastName = model.LastName, Email = model.Email };
            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);
                return result;
            }
            else
            {
                return IdentityResult.Failed();
            }
        }

        public async Task<SignInResult> OnLoginPostAsync(LoginUserInputModel model)
        {
            var user = this.dbService.DbContext.Users.FirstOrDefault(x => x.UserName == model.Username);
            if (user == null)
            {
                return SignInResult.Failed;
            }
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, set lockoutOnFailure: true
            bool RememberMe = model.RememberMe == "RememberMe";
            var result = await signInManager.PasswordSignInAsync(user, model.Password, RememberMe, lockoutOnFailure: true);
            return result;
        }

        public EventureUser GetUser(ClaimsPrincipal principal)
        {
            EventureUser user = this.userManager.GetUserAsync(principal).GetAwaiter().GetResult();

            return user;
        }
    }
}