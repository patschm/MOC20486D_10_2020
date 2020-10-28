using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Fakes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestService.Controllers
{
    //[Route("person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [Route("person/all")]
        public List<Person> Get()
        {
            PersonFake fk = new PersonFake();
            return fk.Generate(40);
        }
        [Route("person/{id}")]
        public Person Get(int id)
        {
            PersonFake fk = new PersonFake();
            return fk.Generate(20).FirstOrDefault(p => p.ID == id);
        }
    }
}
