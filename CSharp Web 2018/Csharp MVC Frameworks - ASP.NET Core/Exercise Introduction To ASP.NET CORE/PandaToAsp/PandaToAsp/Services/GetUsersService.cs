namespace PandaToAsp.Services
{
    using Microsoft.EntityFrameworkCore;
    using Panda.Models;
    using PandaToAsp.Data;
    using PandaToAsp.Services.Contracts;
    using System.Linq;

    public class GetUsersService : IGetUsersService
    {
        private readonly PandaDbContext db;

        public GetUsersService(PandaDbContext db)
        {
            this.db = db;
        }

        public PandaUser[] GetUsers()
        {
            var users = 
                this.db
                .Users
                .Include(u => u.Receipts)
                .ThenInclude(r => r.Package)
                .ToArray();

            return users;
        }
    }
}
