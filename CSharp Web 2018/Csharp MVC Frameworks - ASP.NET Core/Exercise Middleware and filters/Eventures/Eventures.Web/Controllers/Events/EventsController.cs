namespace Eventures.Web.Controllers.Events
{
    using Eventures.Web.Filters;
    using Eventures.Web.Services.Events.Contracts;
    using Eventures.Web.ViewModels.Events;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;

    public class EventsController : BaseController
    {
        private readonly IEventsService eventsService;
        private readonly ILogger<EventsController> logger;

        public EventsController(IEventsService eventsService, ILogger<EventsController> logger)
        {
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
            if (ModelState.IsValid)
            {
                var result = this.eventsService.AddEvent(model, this.User);

                this.logger.LogInformation($"Event created: {model.Name}");
               
                if(result is PageResult)
                {
                    result = this.View(model);
                }

                return result;
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

            return this.View(events);
        }
    }
}