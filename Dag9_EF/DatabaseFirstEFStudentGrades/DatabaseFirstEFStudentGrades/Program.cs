using DatabaseFirstEFStudentGrades.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstEFStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Database first");

            using (var ctx = new StudentsGradesEntities())
            {
                var students = ctx.Students.ToList();
                foreach (Students s in students)
                {
                    Console.WriteLine();
                    Console.WriteLine(s.Name);
                    var grades = s.Grades.ToList();
                    foreach (Grades g in grades)
                    {
                        Console.WriteLine($"{g.Course} : {g.Grade}");
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
