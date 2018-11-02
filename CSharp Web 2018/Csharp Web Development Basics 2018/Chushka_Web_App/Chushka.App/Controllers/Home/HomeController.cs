namespace Chushka.App.Controllers.Home
{
    using Chushka.App.ViewModels.Products;
    using SIS.HTTP.Responses;
    using System.Linq;

    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            var products =
                this.DbContext
                .Products
                .Select(p => new AllProductsViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price
                })
                .ToArray();

            return this.View(products);
        }
    }
}