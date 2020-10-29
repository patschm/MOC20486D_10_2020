using System.Linq;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;

namespace RestService.Controllers
{
    [Route("person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonRepository _repository;

        public PersonController(IPersonRepository repo)
        {
            _repository = repo;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get([FromQuery]int skip = 0, [FromQuery]int take = 10)
        {
            var query = _repository.Get().Skip(skip).Take(take);
            return Ok(query.ToList());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var query = _repository.Get().Where(p => p.ID == id);            
            return Ok(query.FirstOrDefault());
        }

        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody]Person px)
        {
            // Voeg toe aan collectie
            px.ID = 2000;
            return Created($"/person/{px.ID}",px);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, [FromBody] Person px)
        {
            // Bestaat hij wel?
            // Niet?
            //return NotFound();
            // Concurrency issue?
            //return Conflict();
            // Voeg toe aan collectie
            px.ID = 2000;
            return Accepted(px);
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            // Bestaat hij wel?
            // Niet?
            //return NotFound();
            // Voeg toe aan collectie
            return Accepted();
        }
    }
}
