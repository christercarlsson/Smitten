using Microsoft.EntityFrameworkCore;
using Smitten.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smitten.Api.Services
{
    public class SmittenRepository : ISmittenRepository
    {
        private SmittenContext _context;

        public SmittenRepository(SmittenContext context) {
            _context = context;
        }

        public IEnumerable<Person> GetPeople() {
            var result = _context
                .People.Include(p => p.Smites)
                .ToList();

            return result;
        }

        public Person GetPerson(int id) {
            var result =_context
                .People
                .Where(p => p.Id == id)
                .Include(p => p.Smites)
                .SingleOrDefault();

            return result;
        }
    }
}
