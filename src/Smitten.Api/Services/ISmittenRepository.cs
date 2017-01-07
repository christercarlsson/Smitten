using Smitten.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smitten.Api.Services
{
    public interface ISmittenRepository
    {
        IEnumerable<Person> GetPeople();
        Person GetPerson(int id);

    }
}
