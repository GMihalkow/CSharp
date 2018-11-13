namespace Chushka.Web.Services.Contracts
{
    using Chushka.Models;
    using Chushka.Web.ViewModels.Products;
    using Microsoft.AspNetCore.Mvc;

    public interface IProductService
    {
        AllProductsViewModel GetAllProducts(string username);

        IActionResult AddProduct(CreateProductViewModel model);

        Product GetProduct(string id);
    }
}