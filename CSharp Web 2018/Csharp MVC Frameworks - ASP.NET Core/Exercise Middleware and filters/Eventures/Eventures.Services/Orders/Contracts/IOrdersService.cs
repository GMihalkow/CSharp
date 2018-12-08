namespace Eventures.Services.Orders.Contracts
{
    using Eventures.Models;
    using System.Collections.Generic;
    using System.Security.Claims;

    public interface IOrdersService
    {
        int AddOrder(int ticketsCount, ClaimsPrincipal principal, string eventName);

        IEnumerable<Order> GetAllOrders();
    }
}