namespace Chushka.App.Controllers.Products
{
    using Chushka.App.Models;
    using Chushka.App.Models.Enums;
    using Chushka.App.ViewModels.Products;
    using Microsoft.EntityFrameworkCore;
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;
    using System;
    using System.Linq;

    public class ProductsController : BaseController
    {
        [Authorize("Admin")]
        public IHttpResponse Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize("Admin")]
        public IHttpResponse Create(CreateProductViewModel model)
        {
            if (model.ProductType == null)
                return BadRequestErrorWithView("You must select a product type.");
            if (model.Price == default(decimal) || model.Price < 0)
                return BadRequestErrorWithView("You must enter a valid number larger than 0.");
            if (model.Name.Trim().Length < 3 || model.Description.Trim().Length < 3 || model.Name.Contains(" "))
                return BadRequestErrorWithView("Invalid product information.");

            var user = this.DbContext.Users.First(u => u.Username == this.User.Username);

            Product product = model.To<Product>();

            //Use Enum.TryParse to check if the enum exists.

            object type;
            Enum.TryParse(typeof(ProductType), model.ProductType, out type);
            if (type == null)
                return this.BadRequestErrorWithView("Invalid product type.");

            product.Type = (ProductType)type;

            if (this.DbContext.Products.Any(p => p.Name == product.Name))
                return this.BadRequestErrorWithView("Product already exists!");

            this.DbContext.Products.Add(product);
            this.DbContext.SaveChanges();

            return this.Redirect($"/products/details?id={product.Id}");
        }

        [Authorize]
        public IHttpResponse Details(int id)
        {
            var product = this.DbContext.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return this.BadRequestError("Product doesn't exist!");

            return this.View(product);
        }

        [Authorize("Admin")]
        public IHttpResponse Edit(int id)
        {
            var product = this.DbContext.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return this.BadRequestError("Product doesn't exist!");

            return this.View(product);
        }

        [Authorize("Admin")]
        [HttpPost]
        public IHttpResponse Edit(UpdateDeleteProductViewModel model)
        {
            var product = this.DbContext.Products.FirstOrDefault(p => p.Id == model.Id);
            if (product == null)
                return this.BadRequestError("Product doesn't exist!");

            if (model.ProductType == null)
                return BadRequestError("You must select a product type.");
            if (model.Price == default(decimal) || model.Price < 0)
                return BadRequestError("You must enter a valid number larger than 0.");
            if (model.Name.Trim().Length < 3 || model.Description.Trim().Length < 3 || model.Name.Contains(" "))
                return BadRequestError("Invalid product information.");

            product.Name = model.Name;
            product.Price = model.Price;
            product.Description = model.Description;
            product.Type = (ProductType)Enum.Parse(typeof(ProductType), model.ProductType);
            this.DbContext.Entry(product).State = EntityState.Modified;
            this.DbContext.SaveChanges();

            return this.Redirect($"/products/details?id={product.Id}");
        }

        [Authorize("Admin")]
        public IHttpResponse Delete(int id)
        {
            var product = this.DbContext.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return this.BadRequestError("Product doesn't exist!");

            return this.View(product);
        }

        [Authorize("Admin")]
        [HttpPost]
        public IHttpResponse Delete(UpdateDeleteProductViewModel model)
        {
            var product = this.DbContext.Products.FirstOrDefault(p => p.Id == model.Id);
            if (product == null)
                return this.BadRequestError("Product doesn't exist!");

            this.DbContext.Products.Remove(product).State = EntityState.Deleted;
            this.DbContext.SaveChanges();

            return this.Redirect($"/");
        }
    }
}