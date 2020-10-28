using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataHost.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataHost.Kontroleurs
{
    [ApiController]
    [Route("person")]
    public class PersonController : ControllerBase
    {
        [HttpGet]
        //[Route("geeft")]
        public Person Get()
        {
            return new Person { ID = 1, Name = "Jan", Age = 42 };
        }
        [HttpPost]
        public string Post()
        {
            return "Hoi";
        }
    }
}
