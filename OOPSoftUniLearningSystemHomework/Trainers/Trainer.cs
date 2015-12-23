using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLR
{
    class Trainer : Person
    {
        protected DataBase database;
        public Trainer(string name, int age, string eMail)
            : base(name, age, eMail)
        {
            this.database = new DataBase();
        }
        public Trainer(string name, int age)
            : base(name, age)
        {
            this.database = new DataBase();
        }
        public void CreateCourse(string courseName)
        {
            Console.WriteLine("Course {0} created.", courseName);
            this.database.AddCourse(new Course(courseName));
        }
    }
}
