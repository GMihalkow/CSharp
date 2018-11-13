namespace Chushka.Web.Services.Contracts
{
    using Chushka.Models;
    using Microsoft.AspNetCore.Mvc;

    public interface IOrderService
    {
        Order[] GetAllOrders();

        IActionResult OrderProduct(Product product, ChushkaUser user);
    }
}