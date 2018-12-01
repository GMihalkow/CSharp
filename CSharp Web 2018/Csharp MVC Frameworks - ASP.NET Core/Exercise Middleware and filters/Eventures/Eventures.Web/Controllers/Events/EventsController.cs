namespace Eventures.Web.Controllers.Events
{
    using AutoMapper;
    using Eventures.Models;
    using Eventures.Services.Events.Contracts;
    using Eventures.Services.Orders.Contracts;
    using Eventures.Web.Filters;
    using Eventures.Web.ViewModels.Events;
    using Eventures.Web.ViewModels.Orders;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Linq;

    public class EventsController : BaseController
    {
        private readonly IOrdersService ordersService;
        private readonly IMapper mapper;
        private readonly IEventsService eventsService;
        private readonly ILogger<EventsController> logger;

        public EventsController(IOrdersService ordersService, IMapper mapper, IEventsService eventsService, ILogger<EventsController> logger)
        {
            this.ordersService = ordersService;
            this.mapper = mapper;
            this.eventsService = eventsService;
            this.logger = logger;
        }

        [Authorize("Admin")]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [TypeFilter(typeof(LogEventFilter))]
        [Authorize("Admin")]
        public IActionResult Create(CreateEventInputModel model)
        {
            var eventuresEvent = this.mapper.Map<Event>(model);

            if (ModelState.IsValid)
            {
                this.eventsService.AddEvent(eventuresEvent, this.User);

                this.logger.LogInformation($"Event created: {model.Name}");
               
                return this.Redirect("/Events/All");
            }
            else
            {
                return this.View(model);
            }
        }

        public IActionResult All(int start)
        {
            var totalEventsCount = 
                this.eventsService
                .AllEventsCount();

            var events = 
                this.eventsService
                .EventsOnOnePage(start);

            var viewModel = new EventsOnPageViewModel
            {
                Events = events,
                Start = start,
                TotalEventsCount = totalEventsCount
            };
            
            return this.View(viewModel);
        }

        public IActionResult My()
        {
            var events = 
                this.eventsService
                .MyEvents(this.User);

            var mappedEvents =
                events
                .Select(e => this.mapper.Map<MyEventsViewModel>(e))
                .ToArray();

            return this.View(mappedEvents);
        }

        [HttpPost]
        public IActionResult All(OrderInputModel model, int start)
        {
            if (ModelState.IsValid)
            {
                this.ordersService.AddOrder(model.TicketsCount, this.User, model.EventName);

                return this.Redirect("/");
            }
            else
            {
                var totalEventsCount =
                    this.eventsService
                    .AllEventsCount();

                var events = 
                    this.eventsService
                    .EventsOnOnePage(start);

                var viewModel = new EventsOnPageViewModel
                {
                    Events = events,
                    Start = start,
                    TotalEventsCount = totalEventsCount
                };

                return this.View(viewModel);
            }
        }
    }
}