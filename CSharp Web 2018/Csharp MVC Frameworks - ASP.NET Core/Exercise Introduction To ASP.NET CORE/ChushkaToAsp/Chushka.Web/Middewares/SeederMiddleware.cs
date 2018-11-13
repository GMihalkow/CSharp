namespace Chushka.Web.Middewares
{
    using Chushka.Web.Utilities;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;

    public class SeederMiddleware
    {
        private readonly RequestDelegate next;

        public SeederMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public Task Invoke(HttpContext httpContext, RoleManager<IdentityRole> roleManager)
        {
            Seeder.SeedRoles(roleManager).Wait();

            return next(httpContext);
        }
    }
}
