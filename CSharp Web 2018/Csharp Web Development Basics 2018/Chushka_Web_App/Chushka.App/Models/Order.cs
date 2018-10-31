namespace Chushka.App.Models
{
    using System;

    public class Order
    {
        public int Id { get; set; }

        public Product Product { get; set; }

        public int ProductId { get; set; }

        public User Client { get; set; }

        public int ClientId { get; set; }

        public DateTime OrderedOn { get; set; } = DateTime.UtcNow;
    }
}