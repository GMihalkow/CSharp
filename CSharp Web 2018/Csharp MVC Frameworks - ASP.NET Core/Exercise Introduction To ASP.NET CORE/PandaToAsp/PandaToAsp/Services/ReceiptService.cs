namespace PandaToAsp.Services
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Panda.Models;
    using PandaToAsp.Data;
    using PandaToAsp.Services.Contracts;

    public class ReceiptService : IReceiptService
    {
        private readonly PandaDbContext dbContext;

        public ReceiptService(PandaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Receipt GetReceipt(string id)
        {
            var receipt =
                this.dbContext
                .Receipts
                .Include(r => r.Package)
                .Include(r => r.Recipient)
                .FirstOrDefault();

            return receipt;
        }
    }
}
