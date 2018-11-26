namespace Eventures.Web.Controllers.Orders
{
    using Eventures.Web.Services.Orders.Contracts;
    using Eventures.Web.ViewModels.Orders;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class OrdersController : BaseController
    {
        private readonly IOrdersService ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }
        
        [HttpPost]
        public IActionResult Order(OrderInputModel model)
        {
            if (ModelState.IsValid)
            {
                this.ordersService.AddOrder(model.TicketsCount, this.User, model.EventName);

                return this.Redirect("/");
            }
            else
            {
                return this.Redirect("/Events/All");
            }
        }

        [Authorize("Admin")]
        public IActionResult All()
        {
            var orders = this.ordersService.GetAllOrders();

            return this.View(orders);
        }
    }
}