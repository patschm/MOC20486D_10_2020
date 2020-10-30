using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Repository.InMemory;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.HttpContext
{
    public class DummyWebApplicationFactory<T>: WebApplicationFactory<T> where T : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(svc => {
                svc.AddTransient<IPersonRepository, PersonRepository>();
            });
        }
    }
}
