using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Chushka.Web.ViewModels.Account
{
    public class RegisterUserViewModel
    {
        [StringLength(100, ErrorMessage = "Username length must between 6 and 100 characters", MinimumLength = 6)]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password length must between 6 and 100 characters", MinimumLength = 6)]
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        [StringLength(100, ErrorMessage = "Full Name length must between 6 and 100 characters", MinimumLength = 6)]
        public string FullName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public bool RememberMe { get; set; }

    }
}
