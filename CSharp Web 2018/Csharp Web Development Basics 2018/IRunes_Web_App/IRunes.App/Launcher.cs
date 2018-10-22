namespace IRunes.App
{
    using IRunes.Data;
    using Microsoft.EntityFrameworkCore;
    using SIS.MvcFramework;

    public class Launcher
    {
        static void Main(string[] args)
        {
            ConfigureDatabase();
            WebHost.Start(new Startup());
        }

        private static void ConfigureDatabase()
        {
            IRunesDbContext context = new IRunesDbContext();
            context.Database.Migrate();
        }
    }
}
