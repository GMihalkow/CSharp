namespace ByTheCake.App
{
    using ByTheCake.App.Controllers;
    using ByTheCake.Data;
    using Microsoft.EntityFrameworkCore;
    using SIS.Framework;
    using SIS.Framework.ActionsResults;
    using SIS.Framework.Routers;
    using SIS.HTTP.Enums;
    using SIS.WebServer;
    using SIS.WebServer.Api.Contracts;
    using SIS.WebServer.Routing;

    public class Launcher
    {
        static void Main(string[] args)
        {
            ConfigureDatabase();

            ControllerRouter controllerRouter = new ControllerRouter();

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
