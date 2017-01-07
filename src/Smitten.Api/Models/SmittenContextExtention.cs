using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smitten.Api.Models
{
    public static class SmittenContextExtention
    {
        public static void  SeedData(this SmittenContext context) {
            if (!context.People.Any()) {
                var people = new List<Person> {
                    new Person {
                        Name = "Pelle Plutt",
                        Smites = new List<Smite> {
                            new Smite {
                                Date = new DateTime(2016, 12, 10, 10, 00, 00)
                            },
                            new Smite {
                                Date = new DateTime(2016, 12, 10, 10, 15, 00)
                            },
                            new Smite {
                                Date = new DateTime(2015, 12, 10, 12, 10, 00)
                            }
                        }
                    },
                    new Person {
                        Name = "Arne Anka",
                        Smites = new List<Smite> {
                            new Smite {
                                Date = new DateTime(2016, 12, 11, 10, 00, 00)
                            },
                            new Smite {
                                Date = new DateTime(2016, 12, 11, 10, 15, 00)
                            },
                            new Smite {
                                Date = new DateTime(2015, 12, 11, 12, 10, 00)
                            }
                        }
                    },
                    new Person {
                        Name = "Efrahim Långstrump",
                        Smites = new List<Smite> {
                            new Smite {
                                Date = new DateTime(2016, 12, 12, 10, 00, 00)
                            },
                            new Smite {
                                Date = new DateTime(2015, 12, 12, 12, 10, 00)
                            }
                        }
                    },

                };

                context.People.AddRange(people);
                context.SaveChanges();
            }
        }
    }
}
