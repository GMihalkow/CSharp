namespace IRunes.App.Controllers
{
    using SIS.Services.MvcFramework;
    using SIS.MvcFramework;
    using IRunes.Data;

    public abstract class BaseController : Controller
    {
        protected BaseController() 
            : base()
        {
            this.Context = new IRunesDbContext();
        }

        protected IRunesDbContext Context { get; }
    }
}