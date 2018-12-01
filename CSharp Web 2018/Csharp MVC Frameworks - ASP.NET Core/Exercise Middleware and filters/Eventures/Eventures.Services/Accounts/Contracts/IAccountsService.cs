namespace Eventures.Services.Accounts.Contracts
{
    using Eventures.Models;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public interface IAccountService
    {
        Task ExternalLogin();

        bool Register(EventureUser model, string password);

        bool Login(EventureUser model, string password);

        Task<bool> UserWithPasswordExists(string username, string password);

        bool UserExists(string username);

        Task<bool> EmailExists(string email);
        
        Task Logout();

        EventureUser GetUserById(string id);

        string GetRoleById(string id);

        EventureUser GetUser(ClaimsPrincipal principal);

        Dictionary<EventureUser, string> GetUsersWithRoles(string currentUser);

        void Promote(string id);

        void Demote(string id);
    }
}