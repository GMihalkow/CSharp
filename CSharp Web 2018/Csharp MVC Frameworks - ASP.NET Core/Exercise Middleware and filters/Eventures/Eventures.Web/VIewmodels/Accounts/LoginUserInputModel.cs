namespace Eventures.Web.ViewModels.Accounts
{
    using Eventures.Models;
    using Eventures.Web.MappingConfigurations;
    using Forum.Web.Attributes;
    using System.ComponentModel.DataAnnotations;

    [UserExists("Invalid loggin attempt.")]
    public class LoginUserInputModel : IMapTo<EventureUser>
    {
        [Required]
        [StringLength(50, ErrorMessage = "{0} must be between {2} and {1} characters long.", MinimumLength = 3)]
        [RegularExpression(@"[a-zA-Z_\-.*~0-9]*")]
        public string Username { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "{0} must be between 5 and 50 characters long.", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string RememberMe { get; set; }
    }
}