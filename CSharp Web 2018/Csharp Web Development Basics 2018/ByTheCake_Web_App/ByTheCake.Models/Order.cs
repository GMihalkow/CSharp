namespace ByTheCake.Models
{
    using System;
    using System.Collections.Generic;

    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public DateTime DateOfCreation { get; set; } = DateTime.UtcNow;

        public ICollection<ProductOrder> Products { get; set; }
    }
}
