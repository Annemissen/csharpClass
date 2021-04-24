using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvedExercises
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext() : base("PersonDb")
        {
        }

        public DbSet<Person> PersonSet { get; set; }

    }
}
