namespace IRunes.App.Controllers
{
    using ByTheCakeApp.ByTheCakeApplication.Services;
    using IRunes.Data;

    public abstract class BaseController
    {
        protected const string EncryptKey = "186fd62b-5806-4b7b-8f76-3b04ad02bee3";

        protected const string AuthenticationCookieKey = "-auth";

        public BaseController()
        {
            this.Context = new IRunesDbContext();
            this.EncryptService = new EncryptService();
            this.HashService = new HashService();
        }

        protected IRunesDbContext Context { get; }

        protected HashService HashService { get; }

        protected EncryptService EncryptService { get; }
    }
}