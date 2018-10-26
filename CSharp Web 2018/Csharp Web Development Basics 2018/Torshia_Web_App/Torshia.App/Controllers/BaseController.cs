namespace Torshia.App.Controllers
{
    using SIS.MvcFramework;
    using System;
    using Torshia.App.Data;

    public class BaseController : Controller
    {
        protected const string AuthenticationCookieKey = "-auth.torshia";

        protected TorshiaDbContext DbContext;

        protected BaseController()
        {
            this.DbContext = new TorshiaDbContext();
        }
    }
}