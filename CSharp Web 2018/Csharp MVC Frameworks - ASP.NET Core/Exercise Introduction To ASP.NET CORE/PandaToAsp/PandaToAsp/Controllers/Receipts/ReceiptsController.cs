namespace PandaToAsp.Controllers.Receipts
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Panda.Models;
    using PandaToAsp.Services.Contracts;
    using PandaToAsp.ViewModels.Receipts;
    using System;

    public class ReceiptsController : Controller
    {
        private readonly IGetReceiptsService getReceiptsService;
        private readonly IReceiptService receiptService;

        public ReceiptsController(IGetReceiptsService getReceiptsService, IReceiptService receiptService)
        {
            this.getReceiptsService = getReceiptsService;
            this.receiptService = receiptService;
        }

        [Authorize]
        public IActionResult Index()
        {
            Receipt[] receipts;

            if (this.User.IsInRole("Admin"))
            {
                receipts = this.getReceiptsService.GetAllReceipts();
            }
            else
            {
                receipts = this.getReceiptsService.GetCurrentUserReceipts(this.User.Identity.Name);
            }

            return this.View(receipts);
        }

        [Authorize]
        public IActionResult Details(string id)
        {
            var receipt = this.receiptService.GetReceipt(id);
            if (receipt == null)
            {
                return this.BadRequest("Invalid receipt id");
            }

            decimal Total = (decimal)receipt.Package.Weight * 2.67m;

            ReceiptDetailsViewModel viewModel = new ReceiptDetailsViewModel
            {
                Id = id,
                IssuedOn = receipt.IssuedOn,
                Description = receipt.Package.Description,
                DeliveryAddress = receipt.Package.ShippingAddress,
                Total = Total,
                Recipient = receipt.Recipient.UserName,
                PackageWeight = receipt.Package.Weight
            };

            return this.View(viewModel);
        }
    }
}