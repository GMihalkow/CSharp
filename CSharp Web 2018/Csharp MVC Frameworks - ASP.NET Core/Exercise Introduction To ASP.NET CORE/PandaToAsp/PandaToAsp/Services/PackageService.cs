namespace PandaToAsp.Services
{
    using Microsoft.EntityFrameworkCore;
    using Panda.Models;
    using PandaToAsp.Data;
    using PandaToAsp.Services.Contracts;
    using PandaToAsp.ViewModels.Packages;
    using System.Linq;

    public class PackageService : IPackageService
    {
        private readonly PandaDbContext dbContext;

        public PackageService(PandaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddPackage(Package package)
        {
            this.dbContext.Add(package);
            this.dbContext.SaveChanges();
        }

        public Package GetPackage(string id)
        {
            Package package = this.dbContext.Packages.Include(p => p.Recipient).FirstOrDefault(p => p.Id == id);

            return package;
        }
    }
}
