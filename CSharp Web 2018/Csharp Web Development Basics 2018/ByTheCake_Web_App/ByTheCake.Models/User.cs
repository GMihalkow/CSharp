namespace ByTheCake.Models
{
    using System;
    using System.Collections.Generic;

    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public DateTime DateOfRegistration { get; set; } = DateTime.UtcNow;

        public ICollection<Order> Orders { get; set; }
    }
}