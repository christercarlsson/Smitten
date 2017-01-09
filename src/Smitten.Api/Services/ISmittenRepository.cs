using Smitten.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smitten.Api.Services
{
    public interface ISmittenRepository
    {
        IEnumerable<Person> GetPeople(bool includeSmites);
        Person GetPerson(int id);
        bool PersonExists(int id);

        IEnumerable<Smite> GetSmitesForPerson(int personId);
        void AddSmiteToPerson(int personId, Smite smite);

        bool Save();
        Smite GetSmiteForPerson(int personId, int smiteId);
        void DeleteSmite(Smite smiteEntity);
    }
}
