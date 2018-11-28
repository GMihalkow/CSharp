namespace Eventures.Services.Events.Contracts
{
    using Eventures.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;

    public interface IEventsService
    {
        void AddEvent(Event model, ClaimsPrincipal user);

        Event[] AllEvents();

        Event GetEvent(string eventName);

        Event[] MyEvents(ClaimsPrincipal principal);

        int GetCurrentBoughtTicketsCount(string eventName);
    }
}