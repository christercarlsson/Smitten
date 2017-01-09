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

        public IEnumerable<Person> GetPeople(bool includeSmites) {
            IEnumerable<Person> people;
            if (includeSmites)
                people = _context.People.Include(p => p.Smites).ToList();
            else
                people = _context.People.ToList();

            return people;
        }
        public Person GetPerson(int id) => _context.People
                                                   .Where(p => p.Id == id)
                                                   .Include(p => p.Smites)
                                                   .SingleOrDefault();
        public bool PersonExists(int id) => _context.People.Any(p => p.Id == id);

        public IEnumerable<Smite> GetSmitesForPerson(int personId) =>
            _context.Smites.Where(s => s.PersonId == personId).ToList();

        public void AddSmiteToPerson(int personId, Smite smite) {
            var person = GetPerson(personId);
            if (person == null) {
                throw new ArgumentException("personId");
            }
            person.Smites.Add(smite);
        }

        public bool Save() => _context.SaveChanges() > 0;

        public Smite GetSmiteForPerson(int personId, int smiteId) => _context.Smites.Where(p => p.PersonId == personId && p.Id == smiteId).SingleOrDefault();

        public void DeleteSmite(Smite smiteEntity) => _context.Smites.Remove(smiteEntity);

    }
}
