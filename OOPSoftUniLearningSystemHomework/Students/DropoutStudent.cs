using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLR.Students
{
    class DropoutStudent : Student
    {
        public DropoutStudent(string name, int age, string eMail, int studentNumber, string dropoutReason)
            : base (name, age, eMail, studentNumber)
        {
            this.DropoutReason = dropoutReason;
        }
        public DropoutStudent(string name, int age, int studentNumber, string dropoutReason)
            : base(name, age, studentNumber)
        {
            this.DropoutReason = dropoutReason;
        }
        public string DropoutReason { get; set; }
        public void Reapply()
        {
            Console.WriteLine(this.DropoutReason);
        }
    }
}
