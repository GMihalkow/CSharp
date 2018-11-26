namespace Eventures.Web.Services.Orders.Contracts
{
    using Eventures.Web.ViewModels.Orders;
    using System.Collections.Generic;
    using System.Security.Claims;

    public interface IOrdersService
    {
        void AddOrder(int ticketsCount, ClaimsPrincipal principal, string eventName);

        IEnumerable<OrderViewModel> GetAllOrders();
    }
}