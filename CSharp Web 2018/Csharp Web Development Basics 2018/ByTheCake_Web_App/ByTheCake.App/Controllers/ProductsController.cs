namespace ByTheCake.App.Controllers
{
    using ByTheCake.Models;
    using SIS.Framework.ActionsResults.Base;
    using SIS.Framework.Attributes.Methods;
    using SIS.HTTP.Requests.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text.RegularExpressions;

    public class ProductsController : BaseController
    {
        private const string InvalidFormatError =
            "<div class=\"alert alert-danger\" style=\"text-align:center\">" +
            "<strong>Warning!</strong> Invalid price, username or url format!" +
            "</div>";

        private const string ProductAlreadyExistsError =
            "<div class=\"alert alert-danger\" style=\"text-align:center\">" +
            "<strong>Warning!</strong> Product already exists!" +
            "</div>";

        [HttpGet]
        public IActionResult AddProduct()
        {
            return this.View("add-product");
        }

        [HttpPost]
        public IActionResult AddProduct(IHttpRequest request)
        {
            Regex ProductNameRegex = new Regex(@"^\w+$");
            Regex ValidUrlRegex = new Regex(@"^\b((http|https):\/\/?)[^\s()<>]+(?:\([\w\d]+\)|([^[:punct:]\s]|\/?))$");

            Dictionary<string, string> parameters = new Dictionary<string, string>();

            string username = this.cookieService.Decrypt(request.Cookies.GetCookie("-auth").Value, EncryptKey);

            int userId = this.DbContext.Users.First(u => u.Username == username).Id;

            string name = request.FormData["name"].ToString();
            string imageUrl = WebUtility.UrlDecode(request.FormData["url"].ToString());
            string stringPrice = request.FormData["price"].ToString();

            bool IsValidDecimal = decimal.TryParse(stringPrice, out var price);

            if (!IsValidDecimal ||
                !ProductNameRegex.Match(name).Success ||
                !ValidUrlRegex.Match(imageUrl).Success)
            {
                parameters.Add("@Error", InvalidFormatError);

                return this.View("add-product-error", parameters);
            }
            //else if (this.DbContext.Users.First(u => u.Username == username).Orders.Any(x => x.Products.Any(p => p.Product.Name == name)))
            //{
            //    parameters.Add("@Error", ProductAlreadyExistsError);

            //    return this.View("add-product-error", parameters);
            //}

            using (this.DbContext)
            {
                Product product = new Product()
                {
                    Name = name,
                    Price = price,
                    ImageUrl = imageUrl
                };

                Order order = new Order()
                {
                    UserId = userId
                };

                ProductOrder productOrder = new ProductOrder()
                {
                    OrderId = order.Id,
                    Order = order,
                    ProductId = product.Id,
                    Product = product
                };

                this.DbContext.Orders.Add(order);
                this.DbContext.ProductOrders.Add(productOrder);
                this.DbContext.Products.Add(product);

                this.DbContext.SaveChanges();
            }

            parameters.Add("@Name", name);
            parameters.Add("@Price", "$" + price.ToString());
            parameters.Add("@Url", imageUrl);

            return this.View("product-view", parameters);
        }
    }
}