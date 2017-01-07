using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smitten.Api.Models;
using Smitten.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smitten.Api.Controllers
{
    [Route("api/dummy")]
    public class DummyController : Controller
    {
        SmittenContext _ctx;

        public DummyController(SmittenContext ctx) {
            _ctx = ctx;
        }

        [HttpGet]
        public IActionResult Get() {
            var resultFromDb = _ctx.People.Include(p => p.Smites).ToList();
            var result = new List<PersonDto>();

            foreach (var person in resultFromDb) {
                var personDto = new PersonDto();
                personDto.Id = person.Id;
                personDto.Name = person.Name;
                foreach (var smite in person.Smites) {
                    var smiteDto = new SmiteDto();
                    smiteDto.Id = smite.Id;
                    smiteDto.Date = smite.Date;
                    personDto.Smites.Add(smiteDto);
                }
                result.Add(personDto);
            }


            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetPerson(int id) {
            var resultfromDb = _ctx.People.Include(s => s.Smites).Where(p => p.Id == id).SingleOrDefault();
            if (resultfromDb == null)
                return NotFound();

            var result = new PersonDto();
            result.Name = resultfromDb.Name;
            result.Id = resultfromDb.Id;
            foreach (var smite in resultfromDb.Smites) {
                var smiteDto = new SmiteDto();
                smiteDto.Id = smite.Id;
                smiteDto.Date = smite.Date;
                result.Smites.Add(smiteDto);
            }

            return Ok(result);
        }
    }
}
