namespace PandaToAsp.Services
{
    using Panda.Models;
    using PandaToAsp.Data;
    using PandaToAsp.Services.Contracts;
    using System.Linq;

    public class GetUserService : IGetUserService
    {
        private readonly PandaDbContext dbContext;

        public GetUserService(PandaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public PandaUser GetUser(string userName)
        {
            PandaUser user = this.dbContext.Users.FirstOrDefault(u => u.UserName == userName);
            return user;
        }
    }
}
