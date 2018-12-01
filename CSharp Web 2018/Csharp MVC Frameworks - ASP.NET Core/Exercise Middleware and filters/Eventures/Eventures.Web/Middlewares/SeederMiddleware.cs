namespace Eventures.Web.Middlewares
{
    using Eventures.Models;
    using Eventures.Services.Events.Contracts;
    using Eventures.Web.Utilities;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Threading.Tasks;

    public class SeederMiddleware
    {
        private readonly RequestDelegate next;
        //private IEventsService eventsService;

        public SeederMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public Task Invoke(HttpContext httpContext, RoleManager<IdentityRole> roleManager, IEventsService eventsService)
        {
            /* this.eventsService = eventsService;

             for (int index = 0; index < 100; index++)
             {
                 Event @event = new Event
                 {
                     Id= Guid.NewGuid().ToString(),
                     Name = $"Event_Number_{index}",
                     Start = DateTime.UtcNow,
                     End = DateTime.UtcNow.AddDays(2),
                     Place = "Sofia",
                     TotalTickets = 23,
                     PricePerTicket = 12
                 };

                 this.eventsService.AddEvent(@event, httpContext.User);
             }*/

            Seeder.SeedRoles(roleManager).Wait();

            return next(httpContext);
        }
    }
}