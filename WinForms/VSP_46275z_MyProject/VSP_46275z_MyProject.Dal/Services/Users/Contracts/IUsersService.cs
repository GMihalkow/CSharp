using VSP_46275z_MyProject.Dal.Models.Users;

namespace VSP_46275z_MyProject.Dal.Services.Users.Contracts
{
    public interface IUsersService
    {
        UserViewModel GetByName(string username);

        void Register(RegisterInputModel model);

        bool Login(LoginInputModel model);
    }
}