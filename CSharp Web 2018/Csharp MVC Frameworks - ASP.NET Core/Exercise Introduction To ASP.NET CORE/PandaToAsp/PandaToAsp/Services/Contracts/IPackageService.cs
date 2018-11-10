namespace PandaToAsp.Services.Contracts
{
    using Panda.Models;
    using PandaToAsp.ViewModels.Packages;

    public interface IPackageService
    {
        void AddPackage(Package package);

        Package GetPackage(string id);

        void ShipPackage(Package package);

        void DeliverPackage(Package package);

        void AcquirePackage(Package package, PandaUser user);
    }
}