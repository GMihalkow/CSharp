using Eventures.Services.Events.Contracts;
using Moq;
using System;
using Xunit;

namespace Eventures.Tests
{
    public class EventuresEventsServiceTests
    {
        private readonly Mock<IEventsService> eventsServiceMock;

        public EventuresEventsServiceTests()
        {
            this.eventsServiceMock = new Mock<IEventsService>();
        }

        [Fact]
        public void AllEventsCount_should_return_correct_result()
        {
            this.eventsServiceMock.Setup(x => x.AllEventsCount()).Returns(103);

            Assert.Equal("103", eventsServiceMock.Object.AllEventsCount().ToString());

            this.eventsServiceMock.Verify(x => x.AllEventsCount(), Times.Once);
        }

        [Fact]
        public void AddEvent_should_return_one()
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

            eventsServiceMock.Setup(x => x.AddEvent(testEvent, null)).Returns(1);

            Assert.Equal("1", eventsServiceMock.Object.AddEvent(testEvent, null).ToString());
            eventsServiceMock.Verify(x => x.AddEvent(testEvent, null), Times.Once);
        }

        [Fact]
        public void EventsOnOnePage_should_return_ten_or_less()
        {
            this.eventsServiceMock.Setup(x => x.EventsOnOnePage(0)).Returns(new Models.Event[10]);

            Assert.True(this.eventsServiceMock.Object.EventsOnOnePage(0).Length <= 10);

            this.eventsServiceMock.Verify(x => x.EventsOnOnePage(0), Times.Once);
        }
    }
}