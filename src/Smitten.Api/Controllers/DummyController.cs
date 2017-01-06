using Microsoft.AspNetCore.Mvc;
using Smitten.Api.Models;
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
            return Ok(1337);
        }
    }
}
