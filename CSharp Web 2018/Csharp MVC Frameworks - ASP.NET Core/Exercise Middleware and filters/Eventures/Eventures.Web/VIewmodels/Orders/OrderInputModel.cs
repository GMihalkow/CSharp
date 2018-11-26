namespace Eventures.Web.ViewModels.Orders
{
    using Eventures.Web.Attributes;

    [CheckTickets(ErrorMessage ="TEST")]
    public class OrderInputModel
    {
        public string EventName { get; set; }
        
        public int TicketsCount { get; set; }
    }
}