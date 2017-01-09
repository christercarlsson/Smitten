using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Smitten.Api.Services;
using Smitten.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smitten.Api.Controllers
{
    [Route("api/people")]
    public class SmitesController : Controller
    {
        private ISmittenRepository _repository;

        public SmitesController(ISmittenRepository repository) {
            _repository = repository;
        }

        [HttpGet("{personId}/smites")]
        public IActionResult GetSmites(int personId) {
            if(_repository.PersonExists(personId)) {
                var smitesForPerson = _repository.GetSmitesForPerson(personId);

                var result = Mapper.Map<IEnumerable<SmiteDto>>(smitesForPerson);
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("{personId}/smites/{smiteId}", Name = "GetSmite")]
        public IActionResult GetSmite(int personId, int smiteId) {
            if (!_repository.PersonExists(personId))
                return NotFound();
            var smite = _repository.GetSmiteForPerson(personId, smiteId);
            if (smite == null)
                return NotFound();

            var smiteDto = Mapper.Map<SmiteDto>(smite);
            return Ok(smiteDto);
        }

        [HttpPost("{personId}/smites")]
        public IActionResult PostSmite(int personId, [FromBody] SmiteCreateDto smiteCreateDto) {
            if (smiteCreateDto == null)
                return BadRequest();

            if (ModelState.IsValid) {
                if (!_repository.PersonExists(personId))
                    return NotFound();

                var finalSmite = Mapper.Map<Models.Smite>(smiteCreateDto);
                _repository.AddSmiteToPerson(personId, finalSmite);

                if (!_repository.Save())
                    return StatusCode(500);

                var createdSmite = Mapper.Map<SmiteDto>(finalSmite);

                return CreatedAtRoute("GetSmite", new { personId = personId, smiteId = createdSmite.Id }, createdSmite);
            }
            return BadRequest();
        }
        [HttpDelete("{personId}/smites/{smiteId}")]
        public IActionResult DeleteSmite(int personID, int smiteId) {
            if (!_repository.PersonExists(personID))
                return NotFound();
            var smiteEntity = _repository.GetSmiteForPerson(personID, smiteId);
            if (smiteEntity == null)
                return NotFound();
            _repository.DeleteSmite(smiteEntity);

            if (!_repository.Save())
                return StatusCode(500);

            return NoContent();
        }
    }
}
