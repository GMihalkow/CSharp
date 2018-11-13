namespace Chushka.Web.Controllers.Products
{
    using Chushka.Models;
    using Chushka.Web.Services.Contracts;
    using Chushka.Web.ViewModels.Products;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize("Admin")]
    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateProductViewModel model)
        {
            return this.productService.AddProduct(model);
        }

        [AllowAnonymous]
        public IActionResult Details(string id)
        {
            Product product = this.productService.GetProduct(id);
            if(product == null)
            {
                return this.BadRequest("Invalid product id");
            }

            return this.View(product);
        }
    }
}