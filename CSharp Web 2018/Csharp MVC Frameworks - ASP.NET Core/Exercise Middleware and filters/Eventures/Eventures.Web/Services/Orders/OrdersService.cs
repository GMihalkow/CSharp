namespace Eventures.Web.Services.Orders
{
    using Eventures.Models;
    using Eventures.Web.Services.Accounts.Contracts;
    using Eventures.Web.Services.DbContext;
    using Eventures.Web.Services.Events.Contracts;
    using Eventures.Web.Services.Orders.Contracts;
    using Eventures.Web.ViewModels.Orders;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;

    public class OrdersService : IOrdersService
    {
        private readonly DbService dbService;
        private readonly IAccountService accountService;
        private readonly IEventsService eventsService;

        public OrdersService(DbService dbService, IAccountService accountService, IEventsService eventsService)
        {
            this.dbService = dbService;
            this.accountService = accountService;
            this.eventsService = eventsService;
        }

        public void AddOrder(int ticketsCount, ClaimsPrincipal principal, string eventName)
        {
            Event currentEvent = this.eventsService.GetEvent(eventName);
            if (currentEvent != null)
            {
                EventureUser user = this.accountService.GetUser(principal);

                Order order = new Order
                {
                    Customer = user,
                    CustomerId = user.Id,
                    OrderedOn = DateTime.UtcNow,
                    Event = currentEvent,
                    EventId = currentEvent.Id,
                    TicketsCount = ticketsCount
                };

                this.dbService.DbContext.Orders.Add(order);
                this.dbService.DbContext.SaveChanges();
            }
        }

        public IEnumerable<OrderViewModel> GetAllOrders()
        {
            var orders =
                this.dbService
                .DbContext
                .Orders
                .Select(o => new OrderViewModel
                {
                    CustomerName = o.Customer.UserName,
                    EventName = o.Event.Name,
                    OrderedOne = o.OrderedOn
                })
                .ToArray();

            return orders;
        }
    }
}