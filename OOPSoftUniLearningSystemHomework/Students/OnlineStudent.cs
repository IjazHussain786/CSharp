using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLR.Students
{
    public class OnlineStudent : CurrentStudent
    {
        public OnlineStudent(string name, int age, string eMail, int studentNumber)
            : base (name, age, eMail, studentNumber)
        {
        }
        public OnlineStudent(string name, int age, int studentNumber)
            : base(name, age, studentNumber)
        {
        }
    }
}
