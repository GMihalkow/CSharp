namespace ByTheCake.Models
{
    using System.Collections.Generic;

    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<ProductOrder> Orders { get; set; }
    }
}
