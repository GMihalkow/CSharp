namespace Chushka.App.Controllers.Orders
{
    using Chushka.App.Models;
    using Chushka.App.Models.Enums;
    using Chushka.App.ViewModels.Orders;
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;
    using System;
    using System.Linq;

    public class OrdersController : BaseController
    {
        [Authorize(nameof(UserRole.Admin))]
        public IHttpResponse All()
        {
            var orders =
                this.DbContext
                .Orders
                .Select(o => new AllOrdersViewModel
                {
                    Id = o.Id,
                    Customer = o.Client.Username,
                    Product = o.Product.Name,
                    OrderedOn = o.OrderedOn
                })
                .ToArray();

            return this.View(orders);
        }

        [Authorize]
        public IHttpResponse Order(int id)
        {
            var product = this.DbContext.Products.FirstOrDefault(p => p.Id == id);
            var user = this.DbContext.Users.FirstOrDefault(p => p.Username == this.User.Username);
            if (product == null)
                return this.BadRequestError("Product doesn't exist");
            if (user == null)
                return this.Redirect("/users/login");

            Order order = new Order()
            {
                ClientId = user.Id,
                ProductId = id
            };

            this.DbContext.Orders.Add(order);
            this.DbContext.SaveChanges();

            return this.Redirect("/");
        }
    }
}