namespace Eventures.Web.Services.Events
{
    using AutoMapper;
    using Eventures.Models;
    using Eventures.Services.Accounts.Contracts;
    using Eventures.Services.Events.Contracts;
    using Eventures.Web.Services.DbContext;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class EventsService : IEventsService
    {
        private const int EventsDisplayedOnPageCount = 10;
        
        private readonly IMapper mapper;
        private readonly DbService dbService;
        private readonly IAccountService accountService;

        public EventsService(IMapper mapper, DbService dbService, IAccountService accountService)
        {
            this.mapper = mapper;
            this.dbService = dbService;
            this.accountService = accountService;
        }

        public int AddEvent(Event model, ClaimsPrincipal user)
        {
            var eventModel = this.mapper.Map<Event>(model);

            this.dbService.DbContext.Events.Add(eventModel);
            return this.dbService.DbContext.SaveChanges();
        }

        public int AllEventsCount()
        {
            var eventsCount =
                this.dbService
                .DbContext
                .Events
                .Count();

            return eventsCount;
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

        public Event[] MyEvents(ClaimsPrincipal principal)
        {
            var user = this.accountService.GetUser(principal);

            var events =
               this.dbService
               .DbContext
               .Orders
               .Where(o => o.Customer.UserName == user.UserName)
               .Select(o => o.Event)
               .Include(o => o.Orders)
               .ToArray();

            return events;
        }

        public Event[] EventsOnOnePage(int start)
        {
            var events =
                this.dbService
                .DbContext
                .Events
                .Skip(start)
                .Take(EventsDisplayedOnPageCount)
                .ToArray();

            return events;
        }
    }
}