namespace Eventures.Web.ViewModels.Accounts
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterUserViewModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "Username must be between 5 and 50 charactersl long.", MinimumLength = 5)]
        public string Username { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Email must be between 5 and 50 charactersl long.", MinimumLength = 5)]
        public string Email { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Password must be between 5 and 50 charactersl long.", MinimumLength = 5)]
        public string Password { get; set; }
        
        [Required]
        [StringLength(50, ErrorMessage = "Password must be between 5 and 50 charactersl long.", MinimumLength = 5)]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First Name must be between 5 and 50 charactersl long.", MinimumLength = 5)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "LastName must be between 5 and 50 charactersl long.", MinimumLength = 5)]
        public string LastName { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "UCN must be between 5 and 10 charactersl long.", MinimumLength = 5)]
        public string UCN { get; set; }

        public string RememberMe { get; set; }
    }
}