namespace Chushka.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterUserViewModel
    {
        [Required(ErrorMessage = "You must enter an username")]
        [StringLength(100, ErrorMessage = "Username length must between 6 and 100 characters", MinimumLength = 6)]
        public string Username { get; set; }

        [Required(ErrorMessage = "You must enter a password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password length must between 6 and 100 characters", MinimumLength = 6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "You must confirm your password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "You must enter a full name")]
        [StringLength(100, ErrorMessage = "Full Name length must between 6 and 100 characters", MinimumLength = 6)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "You must enter an email address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
