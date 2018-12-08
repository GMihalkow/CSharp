using Eventures.Models;
using Eventures.Services.Orders.Contracts;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Eventures.Tests
{
    public class EventuresOrdersServiceTests
    {
        private readonly Mock<IOrdersService> ordersServiceMock;

        public EventuresOrdersServiceTests()
        {
            this.ordersServiceMock = new Mock<IOrdersService>();
        }

        [Fact]
        public void AddOrder_should_return_correct_result()
        {
            this.ordersServiceMock.Setup(x => x.AddOrder(1, null, "Event_Number_8")).Returns(1);

            Assert.Equal("1", this.ordersServiceMock.Object.AddOrder(1, null, "Event_Number_8").ToString());

            this.ordersServiceMock.Verify(x => x.AddOrder(1, null, "Event_Number_8"), Times.Once);
        }

        [Fact]
        public void GetAllOrders_should_return_correct_result()
        {
            this.ordersServiceMock.Setup(x => x.GetAllOrders()).Returns(new List<Order> { new Order() });

            Assert.Equal("1", this.ordersServiceMock.Object.GetAllOrders().Count().ToString());

            this.ordersServiceMock.Verify(x => x.GetAllOrders(), Times.Once);
        }
    }
}