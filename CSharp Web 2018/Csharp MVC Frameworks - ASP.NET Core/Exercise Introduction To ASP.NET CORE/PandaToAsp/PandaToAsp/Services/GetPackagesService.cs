namespace PandaToAsp.Services
{
    using Panda.Models;
    using PandaToAsp.Data;
    using PandaToAsp.Services.Contracts;
    using System.Linq;

    public class GetPackagesService : IGetPackagesService
    {
        private readonly PandaDbContext dbContext;

        public GetPackagesService(PandaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Package[] GetDelvieredPackages()
        {
            var delivered = 
                this.dbContext
                .Packages
                .Where(p => p.Status.ToString() == "Delivered")
                .ToArray();

            return delivered;
        }

        public Package[] GetPendingPackages()
        {
            var pending =
               this.dbContext
               .Packages
               .Where(p => p.Status.ToString() == "Pending")
               .ToArray();

            return pending;
        }

        public Package[] GetShippedPackages()
        {
            var shipped =
                  this.dbContext
                  .Packages
                  .Where(p => p.Status.ToString() == "Shipped")
                  .ToArray();

            return shipped;
        }
    }
}
