using Application.Model;
using Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace RESTWithASPNETUdemy.Controllers.V2
{
    [ApiVersion("2")]
    [ApiController]
    [Route("api/v{version:apiVersion}/persons")]
    public class PersonControllerV2 : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly ILogger<PersonControllerV2> _logger;

        public PersonControllerV2(ILogger<PersonControllerV2> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<PersonModel> persons = _personService.ListAll();
            if (persons == null || !persons.Any())
                return NotFound();
            return Ok(persons);
        }

        [HttpGet("{id}/{name}")]
        public IActionResult Get(long id, string name)
        {
            var person = _personService.FindByID(id);
            if (person == null)
                return NotFound();
            return Ok(_personService.FindByID(id));
        }

        [HttpPost]
        public IActionResult Post(PersonModel person)
        {
            if (person == null)
                return BadRequest();
            return Ok(_personService.Create(person));
        }

        [HttpPut]
        public IActionResult Put(PersonModel person)
        {
            if (person == null)
                return BadRequest();
            return Ok(_personService.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}
