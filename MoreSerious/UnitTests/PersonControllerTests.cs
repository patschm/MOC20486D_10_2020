using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Logging;
using Repository.InMemory;
using RestService.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class PersonControllerTests : IClassFixture<WebApplicationFactory<RestService.Startup>>
    {
        private WebApplicationFactory<RestService.Startup> _factory;
        
        public PersonControllerTests(WebApplicationFactory<RestService.Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public void TestGetAll()
        {
            // Arrange
            PersonRepository repo = new PersonRepository();
            PersonController ctrl = new PersonController(repo);

            // Act
            var ar = ctrl.Get();

            // Assert
            Assert.NotNull(ar);         
        }

        [Theory]
        [InlineData("/person")]
        public async Task TestGetAllResult(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var result = await client.GetAsync(url);

            // Assert
            Assert.Equal(200, (int)result.StatusCode);
        }
    }
}
