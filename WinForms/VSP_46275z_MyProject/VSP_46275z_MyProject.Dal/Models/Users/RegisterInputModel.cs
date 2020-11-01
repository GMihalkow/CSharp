using VSP_46275z_MyProject.Dal.Infrastructure;
using VSP_46275z_MyProject.Dal.Models.Common.Contracts;
using VSP_46275z_MyProject.Data.Infrastructure;

namespace VSP_46275z_MyProject.Dal.Models.Users
{
    public class RegisterInputModel : IValidateModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public bool Validate()
        {
            if (this.Username.IsNullOrEmpty() || this.Username.Length > Constants.UsernameMaxLength)
                return false;
            else if (this.Password.IsNullOrEmpty() || this.Password.Length > Constants.PasswordMaxLength)
                return false;
            else if (this.ConfirmPassword.IsNullOrEmpty() || this.ConfirmPassword.Length > Constants.PasswordMaxLength)
                return false;
            else if (this.ConfirmPassword != this.Password)
                return false;

            return true;
        }
    }
}