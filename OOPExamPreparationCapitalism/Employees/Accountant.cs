using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamPreparation_Capitalism.Departments;

namespace ExamPreparation_Capitalism.Employees
{
    class Accountant : Employee
    {
        public Accountant(string firstName, string lastName, PositionType position, 
            Company worksInCompany, Department worksInDepartment = null)
            : base(firstName, lastName, position, worksInCompany, worksInDepartment)
        {
        }
        public override decimal Salary
        {
            get
            {
                return (this.WorksInDepartment.DefaultSalaryPercentage - 1) / 100m * this.WorksInCompany.CEO.Salary;
            }
        }
    }
}
