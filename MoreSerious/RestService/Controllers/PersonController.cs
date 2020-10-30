using System;
using System.Linq;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Repository.Interfaces;
using RestService.Configuration;
using RestService.Filters;

namespace RestService.Controllers
{
    [Route("person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonRepository _repository;
        private ILogger<PersonController> _logger;
        private IOptions<MijnData> _options;

        public PersonController(IPersonRepository repo, ILogger<PersonController> logger, IOptions<MijnData> options)
        {
            _repository = repo;
            _logger = logger;
            _options = options;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get([FromQuery]int skip = 0, [FromQuery]int take = 10)
        {
            //throw new Exception("Hallo!!!");
            _logger.LogDebug("Debug");
            _logger.LogError("Error");
            _logger.LogWarning("Warning");
            _logger.LogCritical(_options.Value.Hallo);
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
