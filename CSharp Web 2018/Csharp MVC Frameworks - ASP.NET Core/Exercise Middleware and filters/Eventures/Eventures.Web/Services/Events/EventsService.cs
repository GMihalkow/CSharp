namespace Eventures.Web.Services.Events
{
    using Eventures.Models;
    using Eventures.Web.Services.Accounts.Contracts;
    using Eventures.Web.Services.DbContext;
    using Eventures.Web.Services.Events.Contracts;
    using Eventures.Web.ViewModels.Events;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Security.Claims;

    public class EventsService : IEventsService
    {
        private readonly DbService dbService;
        private readonly IAccountService accountService;

        public EventsService(DbService dbService, IAccountService accountService)
        {
            this.dbService = dbService;
            this.accountService = accountService;
        }

        public IActionResult AddEvent(CreateEventInputModel model, ClaimsPrincipal user)
        {
            if (this.dbService.DbContext.Events.Any(e => e.Name == model.Name))
            {
                return new PageResult();
            }

            Event eventModel = new Event
            {
                Name = model.Name,
                Place = model.Place,
                TotalTickets = model.TotalTickets,
                Start = model.Start,
                End = model.End,
                PricePerTicket = model.PricePerTicket
            };

            this.dbService.DbContext.Events.Add(eventModel);
            this.dbService.DbContext.SaveChanges();

            var result = new RedirectResult("/");

            return result;
        }

        public Event[] AllEvents()
        {
            var events =
                this.dbService
                .DbContext
                .Events
                .ToArray();

            return events;
        }

        public Event GetEvent(string eventName)
        {
            Event currentEvent = this.dbService.DbContext.Events.FirstOrDefault(e => e.Name == eventName);

            return currentEvent;
        }

        public int GetCurrentBoughtTicketsCount(string eventName)
        {
            var currentTicketsCount =
                this.dbService
                .DbContext
                .Orders
                .Include(o => o.Event)
                .Where(o => o.Event.Name == eventName)
                .Sum(o => o.TicketsCount);

            return currentTicketsCount;
        }

        public MyEventsViewModel[] MyEvents(ClaimsPrincipal principal)
        {
            var events =
               this.dbService
               .DbContext
               .Orders
               .Where(o => o.Customer.UserName == this.accountService.GetUser(principal).UserName)
               .Select(o => new MyEventsViewModel
               {
                   EventName = o.Event.Name,
                   EndDate = o.Event.End,
                   StartDate = o.Event.Start,
                   MyTickets = o.TicketsCount
               })
               .ToArray();

            return events;
        }
    }
}