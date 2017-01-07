using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smitten.Api.Models
{
    public class SmittenContext : DbContext
    {
        public SmittenContext(DbContextOptions<SmittenContext> options) : base(options) {
            Database.Migrate();
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Smite> Smites { get; set; }
    }
}
