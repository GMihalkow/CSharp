namespace Chushka.Web.Controllers.Home
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using Chushka.Web.Models;
    using Chushka.Web.Services.Contracts;
    using Chushka.Models;
    using Chushka.Web.ViewModels.Products;

    public class HomeController : Controller
    {
        private readonly IProductService productService;

        public HomeController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Index()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                AllProductsViewModel viewModel = this.productService.GetAllProducts(this.User.Identity.Name);
                return View(viewModel);
            }
            else
            {
                return View();
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
