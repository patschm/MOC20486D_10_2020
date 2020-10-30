using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataHost.Data;
using DataHost.Hubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace DataHost.Kontroleurs
{
    [ApiController]
    [Route("person")]
    public class PersonController : ControllerBase
    {
        private IHubContext<Chatbox> _hub;

        public PersonController(IHubContext<Chatbox> hub)
        {
            _hub = hub;
        }

        [HttpGet]
        //[Route("geeft")]
        public async Task<Person> Get()
        {
            await _hub.Clients.All.SendAsync("Joehoe", "aha Ho");
            return new Person { ID = 1, Name = "Jan", Age = 42 };
        }
        [HttpPost]
        public string Post()
        {
            return "Hoi";
        }
    }
}
