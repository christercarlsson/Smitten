using AutoMapper;
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

            var result = Mapper.Map<IEnumerable<PersonDto>>(resultFromDb);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetPerson(int id) {
            var resultfromDb = _ctx.People.Include(s => s.Smites).Where(p => p.Id == id).SingleOrDefault();
            if (resultfromDb == null)
                return NotFound();

            var result = Mapper.Map<PersonDto>(resultfromDb);

            return Ok(result);
        }
    }
}
