namespace ByTheCake.App
{
    using ByTheCake.App.Controllers;
    using ByTheCake.Data;
    using Microsoft.EntityFrameworkCore;
    using SIS.Framework;
    using SIS.Framework.ActionsResults;
    using SIS.Framework.Routers;
    using SIS.Framework.Services;
    using SIS.HTTP.Enums;
    using SIS.WebServer;
    using SIS.WebServer.Api.Contracts;
    using SIS.WebServer.Routing;

    public class Launcher
    {
        static void Main(string[] args)
        {
            ConfigureDatabase();

            DependencyContainer dependencyContainer = new DependencyContainer();

            ControllerRouter controllerRouter = new ControllerRouter(dependencyContainer);

            Server server = new Server(8002, controllerRouter);
            MvcEngine.Run(server);
        }

        private static void ConfigureDatabase()
        {
            ByTheCakeDbContext context = new ByTheCakeDbContext();
            context.Database.Migrate();
        }

        
    }
}
