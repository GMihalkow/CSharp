namespace PandaToAsp.Services.Contracts
{
    using Panda.Models;

    public interface IGetReceiptsService
    {
        Receipt[] GetCurrentUserReceipts(string username);

        Receipt[] GetAllReceipts();
    }
}
