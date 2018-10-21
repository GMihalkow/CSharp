namespace IRunes.App
{
    using SIS.MvcFramework.Contracts;
    using SIS.MvcFramework.Contracts.Services;
    using SIS.MvcFramework.Logger;
    using SIS.MvcFramework.Logger.Contacts;
    using SIS.MvcFramework.Services;
    using SIS.MvcFramework.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Startup : IMvcApplication
    {
        public void Configure()
        {
        }

        public void ConfigureServices(IServiceCollection collection)
        {
            //TODO: Implement IoC/DI container
            collection.AddService<IHashService, HashService>();
            collection.AddService<IUserCookieService, UserCookieService>();
            collection.AddService<ILogger, FileLogger>();
            collection.AddService<ILogger>(() => new FileLogger("log.txt"));
        }
    }
}
