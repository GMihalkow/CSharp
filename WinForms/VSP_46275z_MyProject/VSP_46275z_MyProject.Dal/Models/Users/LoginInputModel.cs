using VSP_46275z_MyProject.Dal.Infrastructure;
using VSP_46275z_MyProject.Dal.Models.Common.Contracts;

namespace VSP_46275z_MyProject.Dal.Models.Users
{
    public class LoginInputModel : IValidateModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public bool Validate()
        {
            if (this.Username.IsNullOrEmpty() || this.Username.Length > ValidationConstants.UsernameMaxLength)
                return false;
            else if (this.Password.IsNullOrEmpty() || this.Password.Length > ValidationConstants.PasswordMaxLength)
                return false;

            return true;
        }
    }
}