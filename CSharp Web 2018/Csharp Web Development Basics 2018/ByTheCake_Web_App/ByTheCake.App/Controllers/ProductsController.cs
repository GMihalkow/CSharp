namespace ByTheCake.App.Controllers
{
    using ByTheCake.Models;
    using SIS.Framework.ActionsResults.Base;
    using SIS.Framework.Attributes.Methods;
    using SIS.Framework.Attributes.Property;
    using SIS.HTTP.Requests.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Text.RegularExpressions;

    public class ProductsController : BaseController
    {
        private const string InvalidFormatError =
            "<div class=\"alert alert-danger\" style=\"text-align:center\">" +
            "<strong>Warning!</strong> Invalid price, username or url format!" +
            "</div>";

        private const string ProductDoesntExistError =
            "<div class=\"alert alert-danger\" style=\"text-align:center\">" +
            "<strong>Warning!</strong> Product doesn't exist!" +
            "</div>";

        private const string ProductAlreadyExistsError =
            "<div class=\"alert alert-danger\" style=\"text-align:center\">" +
            "<strong>Warning!</strong> Product already exists!" +
            "</div>";

        [HttpGet]
        public IActionResult GetBrowseProducts(IHttpRequest request)
        {
            if (!request.Cookies.ContainsCookie(AuthenticationCookieKey) ||
                (request.Cookies.ContainsCookie(AuthenticationCookieKey) && (request.Cookies.GetCookie(AuthenticationCookieKey).Expires < DateTime.UtcNow)))
                return this.RedirectToAction("/Users/Login");

            return this.View("browse-products");
        }

        [HttpGet]
        public IActionResult ViewProduct(IHttpRequest request)
        {
            int productId = int.Parse(request.QueryData["productId"].ToString());

            if (!this.DbContext.Products.Any(pr => pr.Id == productId))
                return this.View("error");

            Product product =
                this.DbContext
                .Products.First(p => p.Id == productId);

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@Name", product.Name },
                {"@Price", product.Price },
                {"@Url", product.ImageUrl }
            };

            return this.View("product-view", parameters);

        }

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

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            string username = this.cookieService.Decrypt(request.Cookies.GetCookie("-auth.cakes").Value, EncryptKey);

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
            else if (this.DbContext.Products.Any(pr => pr.Name == name))
            {
                parameters.Add("@Error", ProductAlreadyExistsError);

                return this.View("add-product-error", parameters);
            }

            using (this.DbContext)
            {
                Product product = new Product()
                {
                    Name = name,
                    Price = price,
                    ImageUrl = imageUrl
                };

                this.DbContext.Products.Add(product);

                this.DbContext.SaveChanges();
            }

            parameters.Add("@Name", name);
            parameters.Add("@Price", "$" + price.ToString());
            parameters.Add("@Url", imageUrl);

            return this.View("product-view", parameters);
        }

        [HttpPost]
        public IActionResult PostBrowseProducts(IHttpRequest request)
        {
            if (!request.Cookies.ContainsCookie(AuthenticationCookieKey) ||
                (request.Cookies.ContainsCookie(AuthenticationCookieKey) && (request.Cookies.GetCookie(AuthenticationCookieKey).Expires < DateTime.UtcNow)))
                return this.RedirectToAction("/Users/Login");

            string cookieData = request.Cookies.GetCookie(AuthenticationCookieKey).Value;

            string productName = request.FormData["product-name"].ToString();
            string username = this.cookieService.Decrypt(cookieData, EncryptKey);

            if (!this.DbContext
                .Products.Any(pr => pr
                .Name == productName))
            {
                Dictionary<string, object> data = new Dictionary<string, object>()
                {
                    {"@Error", ProductDoesntExistError }
                };

                return this.View("browse-products-error", data);
            }

            StringBuilder sb = new StringBuilder();

            var product =
                this.DbContext
                .Products
                .Where(p => p.Name == productName)
                .First();

            sb.AppendLine($"<a href=\"/Products/ViewProduct?productId={product.Id}\">{product.Name}</a> ${product.Price} <button style=\"margin-left:10%\" class=\"btn btn-primary\" onclick=\"location.href='/Orders/OrderProduct?productId={product.Id}'\">Order</button>");

            Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    {"@Products", sb.ToString().TrimEnd() }
                };


            return this.View("browse-products-with-products", parameters);
        }
    }
}