using Eventures.Web;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net;
using Xunit;

namespace Eventures.IntegrationTests
{
    public class UnitTest1 : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> factory;

        public UnitTest1(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        [Fact]
        public void Test1()
        {
            var server = this.factory.CreateClient();

            var content = server.GetAsync("/");
            content.Start();

            Assert.True(content.Result.StatusCode == HttpStatusCode.OK);
        }
    }
}
