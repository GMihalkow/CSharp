namespace PandaToAsp.Controllers.Receipts
{
    using Microsoft.AspNetCore.Mvc;
    using PandaToAsp.Services.Contracts;
    using System;

    public class ReceiptsController : Controller
    {
        private readonly IGetReceiptsService getReceiptsService;

        public ReceiptsController(IGetReceiptsService getReceiptsService)
        {
            this.getReceiptsService = getReceiptsService;
        }

        public IActionResult Index()
        {
            var receipts = this.getReceiptsService.GetReceipts();

            return this.View(receipts);
        }
    }
}