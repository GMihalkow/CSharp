using System.Linq;
using VSP_46275z_MyProject.Dal.Models.Users;
using VSP_46275z_MyProject.Dal.Services.Password;
using VSP_46275z_MyProject.Dal.Services.Password.Contracts;
using VSP_46275z_MyProject.Dal.Services.Users.Contracts;
using VSP_46275z_MyProject.Data.Data;
using VSP_46275z_MyProject.Models;

namespace VSP_46275z_MyProject.Dal.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly MyProjectDbContext _dbContext;
        private readonly IPasswordService _passwordService;
        
        public UsersService()
        {
            this._passwordService = new PasswordService();
            this._dbContext = new MyProjectDbContext();
        }

        public UserViewModel GetByName(string username)
        {
            var user = this._dbContext.Users.FirstOrDefault(u => u.Username == username);

            if (user == null)
                return null;

            var userViewModel = new UserViewModel
            {
                Id = user.Id,
                Username = user.Username
            };

            return userViewModel;
        }

        public bool Login(LoginInputModel model)
        {
            var passwordHash = this._passwordService.Hash(model.Password);

            return this._dbContext.Users.Any(u => u.Username == model.Username && u.PasswordHash == passwordHash);
        }

        public void Register(RegisterInputModel model)
        {
            var user = new User
            {
                Username = model.Username,
                PasswordHash = this._passwordService.Hash(model.Password)
            };

            this._dbContext.Users.Add(user);
            this._dbContext.SaveChanges();
        }
    }
}