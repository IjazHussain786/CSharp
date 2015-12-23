using SoftUniLR.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLR
{
    class OnsiteStudent : CurrentStudent
    {
        private int numberOfVisits;
        public OnsiteStudent(string name, int age, string eMail, int studentNumber)
            : base (name, age, eMail, studentNumber)
        {
        }
        public OnsiteStudent(string name, int age, int studentNumber)
            : base(name, age, studentNumber)
        {
        }
        public int NumberOfVisits { get; set; }
    }
}
