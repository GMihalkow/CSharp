namespace Eventures.Web.Attributes
{
    using Eventures.Models;
    using Eventures.Web.Services.Events.Contracts;
    using Eventures.Web.Services.Orders.Contracts;
    using Eventures.Web.ViewModels.Orders;
    using System;
    using System.ComponentModel.DataAnnotations;

    [AttributeUsage(AttributeTargets.Class)]
    public class CheckTicketsAttribute : ValidationAttribute
    {
        private IEventsService eventsService;
        private IOrdersService ordersService;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            this.eventsService = (IEventsService)validationContext.GetService(typeof(IEventsService));
            this.ordersService = (IOrdersService)validationContext.GetService(typeof(IOrdersService));

            OrderInputModel model = (OrderInputModel)value;
            Event currentEvent = this.eventsService.GetEvent(model.EventName);
            

            var currentTicketsCountForEvent = this.eventsService.GetCurrentBoughtTicketsCount(model.EventName);
            if (!((currentTicketsCountForEvent + model.TicketsCount) >= currentEvent.TotalTickets))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Not enough tickets left for event.");
        }
    }
}