namespace MishMash.App.Controllers
{
    using MishMash.App.Data;
    using SIS.MvcFramework;

    public abstract class BaseController : Controller
    {
        protected const string AuthenticationCookieKey = "-auth.mish";

        protected BaseController()
        {
            this.DbContext = new MishMashDbContext();
        }
        
        protected MishMashDbContext DbContext { get; set; }
    }
}
