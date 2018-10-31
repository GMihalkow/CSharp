namespace Chushka.App.Models
{
    using Chushka.App.Models.Enums;
    using System.Collections.Generic;

    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public ProductType Type { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}