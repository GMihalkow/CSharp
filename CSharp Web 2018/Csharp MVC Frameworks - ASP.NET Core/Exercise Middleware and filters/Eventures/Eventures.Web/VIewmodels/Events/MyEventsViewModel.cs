namespace Eventures.Web.ViewModels.Events
{
    using System;

    public class MyEventsViewModel
    {
        public string EventName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int MyTickets { get; set; }
    }
}