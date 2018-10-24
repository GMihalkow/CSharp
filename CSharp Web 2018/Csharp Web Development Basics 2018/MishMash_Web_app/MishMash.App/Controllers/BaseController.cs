namespace MishMash.App.Controllers
{
    using Microsoft.EntityFrameworkCore;
    using MishMash.App.Data;
    using SIS.MvcFramework;

    public abstract class BaseController : Controller
    {
        protected const string AuthenticationCookieKey = "-auth.mish";

        protected BaseController()
        {
            this.DbContext = new MishMashDbContext();
            //this.DbContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Tags ON");
            //this.DbContext.SaveChanges();
        }

        protected MishMashDbContext DbContext { get; set; }
    }
}
