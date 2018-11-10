namespace PandaToAsp.Controllers.Packages
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Panda.Models;
    using Panda.Models.Enums;
    using PandaToAsp.Services.Contracts;
    using PandaToAsp.ViewModels.Packages;

    public class PackagesController : Controller
    {
        private readonly IPackageService packageService;
        private readonly IGetUserService getUserService;
        private readonly IGetUsersService getUsersService;
        private readonly IGetPackagesService getPackagesService;

        public PackagesController(IPackageService packageService, IGetUserService getUserService, IGetUsersService getUsersService, IGetPackagesService getPackagesService)
        {
            this.packageService = packageService;
            this.getUserService = getUserService;
            this.getUsersService = getUsersService;
            this.getPackagesService = getPackagesService;
        }

        [Authorize("Admin")]
        public IActionResult Create()
        {
            var users = getUsersService.GetUsers();

            return this.View(users);
        }

        [Authorize("Admin")]
        [HttpPost]
        public IActionResult Create(CreatePackageViewModel model)
        {
            var user = getUserService.GetUser(model.Recepient);
            if (user == null)
            {
                return this.BadRequest("Invalid recipient username.");
            }

            model.Status = Status.Pending;

            Package package = new Package()
            {
                Description = model.Description,
                RecipientId = user.Id,
                Recipient = user,
                ShippingAddress = model.ShippingAddress,
                Status = model.Status,
                Weight = model.Weight,
                DeliveryDate = null,
            };

            this.packageService.AddPackage(package);

            return this.Redirect($"/Packages/Details?id={package.Id}");
        }

        [Authorize]
        public IActionResult Details(string id)
        {
            Package package = this.packageService.GetPackage(id);
            if (package == null)
            {
                return this.BadRequest("Inavlid package id");
            }

            CreatePackageViewModel viewModel = new CreatePackageViewModel()
            {
                DeliveryDate = package.DeliveryDate,
                Description = package.Description,
                Status = package.Status,
                ShippingAddress = package.ShippingAddress,
                Recepient = package.Recipient.UserName,
                Weight = package.Weight
            };

            return this.View(viewModel);
        }

        [Authorize("Admin")]
        public IActionResult Pending()
        {
            var pending = getPackagesService.GetPendingPackages();

            return this.View(pending);
        }

        [Authorize("Admin")]
        public IActionResult Shipped()
        {
            var shipped = getPackagesService.GetShippedPackages();

            return this.View(shipped);
        }

        [Authorize("Admin")]
        public IActionResult Delivered()
        {
            var delivered = getPackagesService.GetDelvieredPackages();

            return this.View(delivered);
        }

        [Authorize("Admin")]
        public IActionResult Ship(string id)
        {
            var package = this.packageService.GetPackage(id);
            if (package == null)
            {
                return this.BadRequest("Invalid package id");
            }

            this.packageService.ShipPackage(package);

            return this.Redirect("/");
        }

        [Authorize("Admin")]
        public IActionResult Deliver(string id)
        {
            var package = this.packageService.GetPackage(id);
            if (package == null)
            {
                return this.BadRequest("Invalid package id");
            }

            this.packageService.DeliverPackage(package);

            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Acquire(string id)
        {
            var user = this.getUserService.GetUser(this.User.Identity.Name);
            if (user == null)
            {
                return this.BadRequest("Invalid user id");
            }

            var package = this.packageService.GetPackage(id);
            if (package == null)
            {
                return this.BadRequest("Invalid package id");
            }

            this.packageService.AcquirePackage(package, user);

            return this.Redirect("/");
        }
    }
}