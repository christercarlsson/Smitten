using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smitten.Api.Models;
using Smitten.Api.Services;
using Smitten.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smitten.Api.Controllers
{
    [Route("api/people")]
    public class PeopleController : Controller
    {
        private ISmittenRepository _repository;

        public PeopleController(ISmittenRepository repository) {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get(bool withSmites) {
            var resultFromDb = _repository.GetPeople(withSmites);

            var result = Mapper.Map<IEnumerable<PersonDto>>(resultFromDb);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetPerson(int id) {
            var resultfromDb = _repository.GetPerson(id);
            if (resultfromDb == null)
                return NotFound();

            var result = Mapper.Map<PersonDto>(resultfromDb);

            return Ok(result);
        }
    }
}
