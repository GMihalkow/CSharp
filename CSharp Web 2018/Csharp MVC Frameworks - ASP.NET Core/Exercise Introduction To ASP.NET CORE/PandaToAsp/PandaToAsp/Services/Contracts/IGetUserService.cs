namespace PandaToAsp.Services.Contracts
{
    using Panda.Models;

    public interface IGetUserService
    {
        PandaUser GetUser(string userName);
    }
}
