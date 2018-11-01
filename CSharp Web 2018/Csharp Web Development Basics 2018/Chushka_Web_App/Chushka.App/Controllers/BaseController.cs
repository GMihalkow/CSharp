namespace Chushka.App.Controllers
{
    using Chushka.App.Data;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Logger;
    using SIS.MvcFramework.Services;

    public class BaseController : Controller
    {
        protected const string AuthenticationCookieKey = "-auth.chushka";

        protected ChuskaDbContext DbContext;

        protected IHashService HashService;

        protected BaseController()
        {
            this.DbContext = new ChuskaDbContext();
            this.HashService = new HashService(new FileLogger());
        }
    }
}
