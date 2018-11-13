namespace Chushka.Web.Services.Contracts
{
    using System;
    using System.Linq;
    using Chushka.Models;
    using Chushka.Web.Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;

    public class OrderService : PageModel, IOrderService
    {
        private readonly ChushkaDbContext dbContext;

        public OrderService(ChushkaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Order[] GetAllOrders()
        {
            Order[] orders =
                this.dbContext
                .Orders
                .Include(o => o.Client)
                .Include(o => o.Product)
                .ToArray();

            return orders;
        }

        public IActionResult OrderProduct(Product product, ChushkaUser user)
        {
            Order order = new Order()
            {
                Product = product,
                ProductId = product.Id,
                Client = user,
                ClientId = user.Id,
                OrderedOn = DateTime.UtcNow
            };

            this.dbContext.Orders.Add(order);
            this.dbContext.SaveChanges();

            return this.Redirect("/");
        }
    }
}