namespace Chushka.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class ChushkaUser : IdentityUser
    {
        public string FullName { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
