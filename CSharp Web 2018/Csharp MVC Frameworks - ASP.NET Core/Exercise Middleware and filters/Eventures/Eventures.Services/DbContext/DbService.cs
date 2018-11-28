namespace Eventures.Web.Services.DbContext
{
    using Eventures.Web.Data;

    public class DbService
    {
        public DbService(EventuresDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public EventuresDbContext DbContext { get; }
    }
}