using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Repository.InMemory;
using RestService.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitTests.HttpContext;
using Xunit;

namespace UnitTests
{
    public class PersonControllerTests : IClassFixture<DummyWebApplicationFactory<RestService.Startup>>
    {
        private DummyWebApplicationFactory<RestService.Startup> _factory;
        
        public PersonControllerTests(DummyWebApplicationFactory<RestService.Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public void TestUpdate_NotFound()
        {
            // Arrange
            PersonRepository repo = new PersonRepository();
            PersonController ctrl = new PersonController(repo, NullLogger<PersonController>.Instance);

            // Act
            var ar = ctrl.Put(2001, new Person()) as NotFoundResult;
       
            // Assert
            Assert.NotNull(ar);
            Assert.Equal(404, ar.StatusCode);
        }

        [Fact]
        public void TestGetAll()
        {
            // Arrange
            PersonRepository repo = new PersonRepository();
            PersonController ctrl = new PersonController(repo, NullLogger<PersonController>.Instance);

            // Act
            var ar = ctrl.Get() as OkObjectResult;
            var data = ar?.Value as List<Person>;

            // Assert
            Assert.NotNull(ar);
            //Assert.Equal(200, ar.StatusCode);
            Assert.NotNull(ar.Value);
            Assert.NotNull(data);
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
