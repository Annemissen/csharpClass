using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstEFStudentsGrades.Model
{
    public class StudentsGradesContext : DbContext
    {
        public StudentsGradesContext() : base()
        {
        }

        public DbSet<Students> StudentsSet { get; set; }
        public DbSet<Grades> GradesSet { get; set; }

    }
}