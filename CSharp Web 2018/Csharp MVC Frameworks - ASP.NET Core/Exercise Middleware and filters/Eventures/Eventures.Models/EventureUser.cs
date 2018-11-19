namespace Eventures.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class EventureUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UCN { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}