namespace PandaToAsp.Services
{
    using Microsoft.EntityFrameworkCore;
    using Panda.Models;
    using PandaToAsp.Data;
    using PandaToAsp.Services.Contracts;
    using System.Linq;

    public class GetReceiptsService : IGetReceiptsService
    {
        private readonly PandaDbContext dbContext;

        public GetReceiptsService(PandaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Receipt[] GetReceipts()
        {
            var receipts = this.dbContext.Receipts.Include(r => r.Recipient).ToArray();
                
            return receipts;
        }
    }
}