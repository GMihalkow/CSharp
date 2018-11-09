namespace PandaToAsp.Services.Contracts
{
    using Panda.Models;

    public interface IGetUsersService
    {
        PandaUser[] GetUsers();
    }
}