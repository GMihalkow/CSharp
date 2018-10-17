namespace ByTheCake.App.Controllers
{
    using ByTheCake.Models;
    using SIS.Framework.ActionsResults.Base;
    using SIS.Framework.Attributes.Methods;
    using SIS.HTTP.Requests.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class OrdersController : BaseController
    {
        [HttpGet]
        public IActionResult OrderProduct(IHttpRequest request)
        {
            string cookieData = request.Cookies.GetCookie(AuthenticationCookieKey).Value;
            int productId = int.Parse(request.QueryData["productId"].ToString());
            string username = this.cookieService.Decrypt(cookieData, EncryptKey);

            User user =
                this.DbContext
                .Users
                .First(u => u.Username == username);

            Product product =
                this.DbContext
                .Products
                .First(pr => pr.Id == productId);

            Order order = new Order()
            {
                UserId = user.Id,
                User = user
            };

            ProductOrder productOrder = new ProductOrder()
            {
                OrderId = order.Id,
                Order = order,
                ProductId = product.Id,
                Product = product
            };

            using (this.DbContext)
            {
                this.DbContext
                .Orders
                .Add(order);

                this.DbContext
                    .ProductOrders
                    .Add(productOrder);

                this.DbContext.SaveChanges();
            }

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@OrderId", order.Id },
                {"@OrderDate", order.DateOfCreation },
                {"@Product", product.Name },
                {"@Price", product.Price.ToString() }
            };

            return this.View("order", parameters);
        }
    }
}