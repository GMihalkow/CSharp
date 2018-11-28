namespace Eventures.Web.Services.Accounts.Contracts
{
    using Eventures.Models;
    using Eventures.Web.ViewModels.Accounts;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public interface IAccountService
    {
        Task ExternalLogin();

        bool Register(RegisterUserViewModel model);

        bool Login(LoginUserInputModel model);

        Task<bool> UserWithPasswordExists(string username, string password);

        bool UserExists(string username);

        Task<bool> EmailExists(string email);
        
        Task Logout();

        EventureUser GetUser(ClaimsPrincipal principal);
    }
}