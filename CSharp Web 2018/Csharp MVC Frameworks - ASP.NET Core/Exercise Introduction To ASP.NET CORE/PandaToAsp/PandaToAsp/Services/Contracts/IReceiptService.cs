namespace PandaToAsp.Services.Contracts
{
    using Panda.Models;

    public interface IReceiptService
    {
        Receipt GetReceipt(string id);
    }
}
