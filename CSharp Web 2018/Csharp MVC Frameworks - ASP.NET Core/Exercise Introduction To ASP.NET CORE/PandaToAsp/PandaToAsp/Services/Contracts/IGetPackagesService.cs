namespace PandaToAsp.Services.Contracts
{
    using Panda.Models;

    public interface IGetPackagesService
    {
        Package[] GetPendingPackages();

        Package[] GetShippedPackages();

        Package[] GetDelvieredPackages();
    }
}
