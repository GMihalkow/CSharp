namespace Eventures.Services.Accounts
{
    using AutoMapper;
    using Eventures.Models;
    using Eventures.Services.Accounts.Contracts;
    using Eventures.Web.Services.DbContext;
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class AccountsService : IAccountService
    {
        private readonly IMapper mapper;
        private readonly DbService dbService;
        private readonly UserManager<EventureUser> userManager;
        private readonly SignInManager<EventureUser> signInManager;

        public AccountsService(IMapper mapper, DbService dbService, UserManager<EventureUser> userManager, SignInManager<EventureUser> signInManager)
        {
            this.mapper = mapper;
            this.dbService = dbService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task ExternalLogin()
        {
            var info = await this.signInManager.GetExternalLoginInfoAsync();

            string email = info.Principal.Claims.First(x => x.Type.Contains("emailaddress")).Value;

            var user = new EventureUser { UserName = email, Email = email };
            if (!(this.dbService.DbContext.Users.Any(x => x.UserName == user.UserName)))
            {
                var createUserResult = await userManager.CreateAsync(user);
                if (createUserResult.Succeeded)
                {
                    createUserResult = await userManager.AddLoginAsync(user, info);
                    if (createUserResult.Succeeded)
                    {
                        await signInManager.SignInAsync(user, isPersistent: false);
                    }
                }
            }

            var result = await this.signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false, true);
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

        public bool Login(EventureUser model, string password)
        {
            var result = this.OnLoginPostAsync(model, password).Result;
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Register(EventureUser model, string password)
        {
            var result = OnRegisterPostAsync(model, password).Result;

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

        public async Task<IdentityResult> OnRegisterPostAsync(EventureUser model, string password)
        {
            var user = this.mapper.Map<EventureUser>(model);
            var result = await userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                if (this.dbService.DbContext.Users.Count() == 1)
                {
                    this.userManager.AddToRoleAsync(model, "Admin").GetAwaiter().GetResult();
                }
                else
                {
                    this.userManager.AddToRoleAsync(model, "User").GetAwaiter().GetResult();
                }

                await signInManager.SignInAsync(user, isPersistent: false);
                return result;
            }
            else
            {
                return IdentityResult.Failed();
            }
        }

        public async Task<SignInResult> OnLoginPostAsync(EventureUser model, string password)
        {
            var user = this.dbService.DbContext.Users.FirstOrDefault(u => u.UserName == model.UserName);
            if (user == null)
            {
                return SignInResult.Failed;
            }
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, set lockoutOnFailure: true
            var result = await signInManager.PasswordSignInAsync(user, password, false, lockoutOnFailure: true);
            return result;
        }

        public EventureUser GetUser(ClaimsPrincipal principal)
        {
            EventureUser user = this.userManager.GetUserAsync(principal).GetAwaiter().GetResult();

            return user;
        }

        public EventureUser GetUserById(string id)
        {
            var user = 
                this.
                dbService
                .DbContext
                .Users
                .FirstOrDefault(u => u.Id == id);

            return user;
        }

        public Dictionary<EventureUser, string> GetUsersWithRoles(string currentUser)
        {
            Dictionary<EventureUser, string> result = new Dictionary<EventureUser, string>();

            var usersWithRoles =
                this.dbService
                .DbContext
                .UserRoles
                .ToArray();

            foreach (var userRole in usersWithRoles)
            {
                var user =
                    this.GetUserById(userRole.UserId);

                if (user.UserName == currentUser)
                {
                    continue;
                }

                var roleName =
                    this.GetRoleById(userRole.RoleId);

                result.Add(user, roleName);
            }

            return result;
        }

        public void Promote(string id)
        {
            //TODO: unit test the promote/demote actions
            var user = this.GetUserById(id);
            if (user != null)
            {
                this.userManager.RemoveFromRoleAsync(user, "User").GetAwaiter().GetResult();
                this.userManager.AddToRoleAsync(user, "Admin").GetAwaiter().GetResult();
            }
        }

        public void Demote(string id)
        {
            var user = this.GetUserById(id);
            if (user != null)
            {
                this.userManager.RemoveFromRoleAsync(user, "Admin").GetAwaiter().GetResult();
                this.userManager.AddToRoleAsync(user, "User").GetAwaiter().GetResult();
            }
        }

        public string GetRoleById(string id)
        {
            var role =
                this.dbService
                .DbContext
                .Roles
                .FirstOrDefault(r => r.Id == id)
                .Name;

            return role;
        }
    }
}