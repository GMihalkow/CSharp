namespace Panda.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;

    public class PandaUser : IdentityUser
    {
        public ICollection<Receipt> Receipts { get; set; }
    }
}