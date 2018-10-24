namespace MishMash.App.ViewModels.Users
{
    using MishMash.App.Models;

    public class PostLoginViewModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }
    }
}
