namespace Eventures.Web.ViewModels.Orders
{
    using Eventures.Models;
    using System;

    public class OrderViewModel
    {
        public string EventName { get; set; }

        public string CustomerName { get; set; }

        public DateTime OrderedOn { get; set; }
    }
}