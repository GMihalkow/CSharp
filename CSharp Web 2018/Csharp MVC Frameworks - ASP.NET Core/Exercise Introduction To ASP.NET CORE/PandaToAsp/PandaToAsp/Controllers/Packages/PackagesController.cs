using Microsoft.AspNetCore.Mvc;
using PandaToAsp.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaToAsp.Controllers.Packages
{
    public class PackagesController : Controller
    {
        private readonly IGetUsersService getUsersService;
        private readonly IGetPackagesService getPackagesService;

        public PackagesController(IGetUsersService getUsersService, IGetPackagesService getPackagesService)
        {
            this.getUsersService = getUsersService;
            this.getPackagesService = getPackagesService;
        }

        public IActionResult Create()
        {
            var users = getUsersService.GetUsers();

            return this.View(users);
        }

        public IActionResult Pending()
        {
            var pending = getPackagesService.GetPendingPackages();

            return this.View(pending);
        }

        public IActionResult Shipped()
        {
            var shipped = getPackagesService.GetShippedPackages();

            return this.View(shipped);
        }

        public IActionResult Delivered()
        {
            var delivered = getPackagesService.GetDelvieredPackages();

            return this.View(delivered);
        }

    }
}
