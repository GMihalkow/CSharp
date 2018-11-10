namespace PandaToAsp.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using PandaToAsp.Models;
    using PandaToAsp.Services.Contracts;

    public class HomeController : Controller
    {
        private readonly IGetUserService getUserService;
        private readonly IGetPackagesService packagesService;

        public HomeController(IGetUserService getUserService, IGetPackagesService packagesService)
        {
            this.getUserService = getUserService;
            this.packagesService = packagesService;
        }

        public IActionResult Index()
        {
            var user = this.getUserService.GetUser(this.User.Identity.Name);
            if(user == null)
            {
                return this.View();
            }
            var packages = this.packagesService.GetCurrentUserPackages(user.Id);

            return this.View(packages);
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
