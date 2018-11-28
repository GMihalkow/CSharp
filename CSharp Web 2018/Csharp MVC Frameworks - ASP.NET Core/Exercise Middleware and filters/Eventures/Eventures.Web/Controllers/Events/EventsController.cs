namespace Eventures.Web.Controllers.Events
{
    using AutoMapper;
    using Eventures.Models;
    using Eventures.Services.Events.Contracts;
    using Eventures.Web.Filters;
    using Eventures.Web.ViewModels.Events;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;
    using System.Linq;

    public class EventsController : BaseController
    {
        private readonly IMapper mapper;
        private readonly IEventsService eventsService;
        private readonly ILogger<EventsController> logger;

        public EventsController(IMapper mapper, IEventsService eventsService, ILogger<EventsController> logger)
        {
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
               
                return this.Redirect("/");
            }
            else
            {
                return this.View(model);
            }
        }

        public IActionResult All()
        {
            var events = this.eventsService.AllEvents();
            
            return this.View(events);
        }

        public IActionResult My()
        {
            var events = this.eventsService.MyEvents(this.User);

            var mappedEvents =
                events
                .Select(e => this.mapper.Map<MyEventsViewModel>(e))
                .ToArray();

            return this.View(mappedEvents);
        }
    }
}