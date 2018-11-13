namespace Chushka.Web.Services
{
    using System;
    using System.Linq;
    using Chushka.Models;
    using Chushka.Web.Data;
    using Chushka.Web.Services.Contracts;
    using Chushka.Web.ViewModels.Products;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;

    public class ProductService : PageModel, IProductService
    {
        private readonly ChushkaDbContext dbContext;
        private readonly IAccountService accountService;

        public ProductService(ChushkaDbContext dbContext, IAccountService accountService)
        {
            this.dbContext = dbContext;
            this.accountService = accountService;
        }

        public IActionResult AddProduct(CreateProductViewModel model)
        {
            Product product = new Product()
            {
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                Type = (ProductType)Enum.Parse(typeof(ProductType), model.ProductType)
            };

            this.dbContext.Products.Add(product);
            this.dbContext.SaveChanges();

            return this.Redirect($"/products/details?id={product.Id}");
        }

        public AllProductsViewModel GetAllProducts(string username)
        {
            Product[] products = this.dbContext.Products.ToArray();
            var user = this.accountService.GetUser(username);

            AllProductsViewModel viewModel = new AllProductsViewModel()
            {
                Products = products,
            };

            return viewModel;
        }

        public Product GetProduct(string id)
        {
            Product product = this.dbContext.Products.FirstOrDefault(x => x.Id == id);

            return product;
        }
    }
}