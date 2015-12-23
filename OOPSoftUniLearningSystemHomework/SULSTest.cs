using SoftUniLR.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLR
{
    class SULSTest
    {
        static void Main()
        {
            List<Student> students = new List<Student>();
            var pesho = new OnsiteStudent("Pesho", 20, 1);
            var gosho = new OnsiteStudent("Gosho", 18, 2);
            pesho.AddGrade("OOP", 2);
            gosho.AddGrade("OOP", 3);
            pesho.AddGrade("Basics", 6);
            gosho.AddGrade("Basics", 6);
            students.Add(pesho);
            students.Add(gosho);
            students.Add(new DropoutStudent("Tsetso", 20, 3, "Lazy student."));
            DropoutStudent tsetso = (DropoutStudent)students.FirstOrDefault(s => s.Name == "Tsetso");
            tsetso.Reapply();
            var currentStudents = students.Where(type => type is CurrentStudent).OrderBy(s => s.AvgGrade).ToList();
            foreach (var curr in currentStudents)
            {
                Console.WriteLine(curr);
            }
        }
    }
}
