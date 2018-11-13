namespace Chushka.Web.ViewModels.Products
{
    using Chushka.Models;

    public class AllProductsViewModel
    {
        public EditDeleteProductViewModel[] Products { get; set; }

        public string OwnerFullName { get; set; }
    }
}
