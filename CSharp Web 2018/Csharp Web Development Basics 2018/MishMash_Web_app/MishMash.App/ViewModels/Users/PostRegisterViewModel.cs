namespace MishMash.App.ViewModels.Users
{
    using MishMash.App.Models;

    public class PostRegisterViewModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public Role Role { get; set; }
    }
}
