namespace Eventures.Web.Services.Accounts.Contracts
{
    using Eventures.Models;
    using Eventures.Web.ViewModels.Accounts;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public interface IAccountService
    {
        IActionResult Register(RegisterUserViewModel model);

        bool Login(LoginUserInputModel model);

        Task<IActionResult> Logout();

        EventureUser GetUser(ClaimsPrincipal principal);
    }
}