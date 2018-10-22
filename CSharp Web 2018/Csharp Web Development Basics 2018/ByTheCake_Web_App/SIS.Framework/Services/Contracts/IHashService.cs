namespace SIS.Framework.Services.Contracts
{
    public interface IHashService
    {
        string Compute256Hash(string rawData);
    }
}