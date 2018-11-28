namespace Eventures.Web.Controllers.Orders
{
    using AutoMapper;
    using Eventures.Services.Orders.Contracts;
    using Eventures.Web.ViewModels.Orders;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    [Authorize]
    public class OrdersController : BaseController
    {
        private readonly IMapper mapper;
        private readonly IOrdersService ordersService;

        public OrdersController(IMapper mapper, IOrdersService ordersService)
        {
            this.mapper = mapper;
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
            //Finish
            var mappedOrders =
                orders
                .Select(o =>
                        this.mapper
                        .Map<OrderViewModel>(o))
                .ToArray();

            this.mapper.Map<OrderViewModel[]>(orders);

            return this.View(mappedOrders);
        }
    }
}