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

        public IActionResult DeleteProduct(string id)
        {
            Product product = this.dbContext.Products.FirstOrDefault(p => p.Id == id);

            this.dbContext.Products.Remove(product).State = EntityState.Deleted;
            this.dbContext.SaveChanges();

            return this.Redirect("/");
        }

        public IActionResult EditProduct(EditDeleteProductViewModel model)
        {
            Product product = this.dbContext.Products.FirstOrDefault(p => p.Id == model.Id);

            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.Type = (ProductType)Enum.Parse(typeof(ProductType), model.ProductType);

            this.dbContext.Entry(product).State = EntityState.Modified;
            this.dbContext.SaveChanges();

            return this.Redirect("/");
        }

        public AllProductsViewModel GetAllProducts(string username)
        {
            EditDeleteProductViewModel[] products = this.dbContext.Products
                .Select(x =>
                new EditDeleteProductViewModel
                {
                    Id = x.Id,
                    Description = x.Description,
                    Name = x.Name,
                    Price = x.Price,
                    ProductType = x.Type.ToString()
                })
                .ToArray();

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