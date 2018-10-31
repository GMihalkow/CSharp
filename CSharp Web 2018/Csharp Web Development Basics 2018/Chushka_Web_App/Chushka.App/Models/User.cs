namespace Chushka.App.Models
{
    using Chushka.App.Models.Enums;
    using System.Collections.Generic;

    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string FullName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public UserRole Role { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}