namespace Chushka.App
{
    using SIS.MvcFramework;
    using SIS.MvcFramework.Services;

    public class Startup : IMvcApplication
    {
        public MvcFrameworkSettings Configure()
        {
            return new MvcFrameworkSettings { PortNumber = 80 };
        }

        public void ConfigureServices(IServiceCollection collection)
        {
        }
    }
}