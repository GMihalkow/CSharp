namespace Eventures.Services.Events.Contracts
{
    using Eventures.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public interface IEventsService
    {
        int AddEvent(Event model, ClaimsPrincipal user);

        Event[] EventsOnOnePage(int start);

        int AllEventsCount();

        Event GetEvent(string eventName);

        Event[] MyEvents(ClaimsPrincipal principal);

        int GetCurrentBoughtTicketsCount(string eventName);
    }
}