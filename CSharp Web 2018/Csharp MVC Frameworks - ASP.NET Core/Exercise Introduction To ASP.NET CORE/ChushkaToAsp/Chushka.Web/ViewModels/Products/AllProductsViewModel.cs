namespace Chushka.Web.ViewModels.Products
{
    using Chushka.Models;

    public class AllProductsViewModel
    {
        public Product[] Products { get; set; }

        public string OwnerFullName { get; set; }
    }
}
