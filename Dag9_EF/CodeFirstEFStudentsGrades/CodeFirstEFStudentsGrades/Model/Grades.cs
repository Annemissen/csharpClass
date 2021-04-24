using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstEFStudentsGrades.Model
{
    public class Grades
    {
        public int GradesId { get; set; }
        public int Grade { get; set; }
        public string Course { get; set; }
        public Students Student { get; set; }
    }
}
