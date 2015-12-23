using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLR
{
    class SeniorTrainer : Trainer
    {
        public SeniorTrainer(string name, int age, string eMail)
            : base(name, age, eMail)
        {
        }
        public SeniorTrainer(string name, int age)
            : base(name, age)
        {
        }
        public void DeleteCourse(string courseName)
        {
            Console.WriteLine("Course {0} deleted.", courseName);
            this.database.RemoveCourse(courseName);
        }
    }
}
