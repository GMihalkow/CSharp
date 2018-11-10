namespace PandaToAsp.Services
{
    using Microsoft.EntityFrameworkCore;
    using Panda.Models;
    using Panda.Models.Enums;
    using PandaToAsp.Data;
    using PandaToAsp.Services.Contracts;
    using PandaToAsp.ViewModels.Packages;
    using System;
    using System.Linq;

    public class PackageService : IPackageService
    {
        private readonly PandaDbContext dbContext;

        public PackageService(PandaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AcquirePackage(Package package, PandaUser user)
        {
            decimal Total = (decimal)package.Weight * 2.67m;

            Receipt receipt = new Receipt
            {
                Package = package,
                PackageId = package.Id,
                IssuedOn = DateTime.Now,
                Recipient = user,
                RecipientId = user.Id,
                Fee = Total
            };

            package.Status = Status.Acquired;

            this.dbContext.Receipts.Add(receipt);
            this.dbContext.SaveChanges();
        }
        
        public void AddPackage(Package package)
        {
            this.dbContext.Add(package);
            this.dbContext.SaveChanges();
        }

        public void DeliverPackage(Package package)
        {
            package.Status = Status.Delivered;
            this.dbContext.SaveChanges();
        }

        public Package GetPackage(string id)
        {
            Package package = this.dbContext.Packages.Include(p => p.Recipient).FirstOrDefault(p => p.Id == id);

            return package;
        }

        public void ShipPackage(Package package)
        {
            int randomDate = new Random().Next(20, 40);

            package.DeliveryDate = DateTime.Now.AddDays(randomDate);
            package.Status = Status.Shipped;

            this.dbContext.SaveChanges();
        }
    }
}
