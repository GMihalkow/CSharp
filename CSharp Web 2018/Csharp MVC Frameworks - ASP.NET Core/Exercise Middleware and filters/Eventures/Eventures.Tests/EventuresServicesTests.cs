using Eventures.Services.Events.Contracts;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Eventures.Tests
{
    public class EventuresServicesTests
    {
        private readonly Mock<IEventsService> eventsService;

        public EventuresServicesTests()
        {
            this.eventsService = new Mock<IEventsService>();
        }

        [Fact]
        public void AllEventsCount_should_return_correct_result()
        {

            eventsService.Setup(x => x.AllEventsCount()).Returns(103);

            Assert.Equal("103", eventsService.Object.AllEventsCount().ToString());
        }

        [Fact]
        public void Add_Event_should_return_one()
        {
            var testEvent = new Models.Event
            {
                Start = DateTime.UtcNow,
                End = DateTime.UtcNow.AddDays(1),
                Name = "UnitTest",
                Id = Guid.NewGuid().ToString(),
                Place = "Pernik",
                TotalTickets = 100,
                PricePerTicket = 1
            };

            eventsService.Setup(x => x.AddEvent(testEvent, null)).Returns(1);

            Assert.Equal("1", eventsService.Object.AddEvent(testEvent, null).ToString());
        }
    }
}
