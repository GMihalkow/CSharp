namespace Eventures.Web.Services.Events.Contracts
{
    using Eventures.Models;
    using Eventures.Web.ViewModels.Events;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;

    public interface IEventsService
    {
        IActionResult AddEvent(CreateEventInputModel model, ClaimsPrincipal user);

        Event[] AllEvents();

        Event GetEvent(string eventName);

        MyEventsViewModel[] MyEvents(ClaimsPrincipal principal);

        int GetCurrentBoughtTicketsCount(string eventName);
    }
}