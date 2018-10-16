namespace ByTheCake.App.Controllers
{
    using ByTheCake.Data;
    using SIS.Framework.Controllers;

    public abstract class BaseController : Controller
    {
        protected BaseController() 
            : base()
        {
            this.DbContext = new ByTheCakeDbContext();
        }

        protected ByTheCakeDbContext DbContext { get; }
    }
}
