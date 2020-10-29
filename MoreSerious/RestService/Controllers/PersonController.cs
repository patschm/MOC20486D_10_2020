using System.Linq;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repository.Interfaces;
using RestService.Filters;

namespace RestService.Controllers
{
    [Route("person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonRepository _repository;
        private ILogger<PersonController> _logger;

        public PersonController(IPersonRepository repo, ILogger<PersonController> logger)
        {
            _repository = repo;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get([FromQuery]int skip = 0, [FromQuery]int take = 10)
        {
            _logger.LogDebug("Debug");
            _logger.LogError("Error");
            _logger.LogWarning("Warning");
            _logger.LogCritical("Critical");
            _logger.LogInformation("Information");

            var query = _repository.Get().Skip(skip).Take(take);
            return Ok(query.ToList());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromRoute]int id)
        {
            var query = _repository.Get().Where(p => p.ID == id);            
            return Ok(query.FirstOrDefault());
        }

        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody]Person px)
        {
            _repository.Insert(px);
            return CreatedAtAction(nameof(Get), new { id=px.ID }, px);
            //return Created($"/person/{px.ID}", px);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put([FromRoute]int id, [FromBody]Person px)
        {
            px.ID = id;
            bool success = _repository.Update(px);
            if (success) return Accepted(px);
            return NotFound();
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            bool success = _repository.Delete(id);
            if (success) return Accepted();
            return NotFound();
        }
    }
}
