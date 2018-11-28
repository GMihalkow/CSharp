namespace Eventures.Web.Filters
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Logging;
    using System;

    public class LogEventFilter : Attribute, IResultFilter
    {
        private readonly ILogger<LogEventFilter> logger;

        public LogEventFilter(ILogger<LogEventFilter> logger)
        {
            this.logger = logger;
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            string username = context.HttpContext.User.Identity.Name;
            string eventName = context.HttpContext.Request.Form["Name"];
            string startDate = context.HttpContext.Request.Form["Start"];
            string endDate = context.HttpContext.Request.Form["End"];

            logger
                .LogInformation($"[{DateTime.UtcNow}] Administrator {username} create event {eventName} ({startDate} / {endDate}).");
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
        }
    }
}