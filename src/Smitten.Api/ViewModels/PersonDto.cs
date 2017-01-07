using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smitten.Api.ViewModels
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfSmites {
            get {
                return Smites.Count;
            }
        }

        public ICollection<SmiteDto> Smites { get; set; } = new List<SmiteDto>();
    }
}
