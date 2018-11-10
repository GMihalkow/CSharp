namespace PandaToAsp.Services.Contracts
{
    using Panda.Models;
    using PandaToAsp.ViewModels.Packages;

    public interface IPackageService
    {
        void AddPackage(Package package);

        Package GetPackage(string id);
    }
}