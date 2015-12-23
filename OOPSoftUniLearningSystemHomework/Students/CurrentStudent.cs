using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLR.Students
{
    public abstract class CurrentStudent : Student
    {
        public CurrentStudent(string name, int age, string eMail, int studentNumber)
            : base (name, age, eMail, studentNumber)
        {
        }
        public CurrentStudent(string name, int age, int studentNumber)
            : base(name, age, studentNumber)
        {
        }
    }
}
