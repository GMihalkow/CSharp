namespace Judge.App.Controllers
{
    using Judge.App.Data;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Logger;
    using SIS.MvcFramework.Services;

    public class BaseController : Controller
    {
        protected JudgeDbContext DbContext;

        protected IHashService hashService;

        protected BaseController()
        {
            this.DbContext = new JudgeDbContext();
            this.hashService = new HashService(new ConsoleLogger());
        }
    }
}