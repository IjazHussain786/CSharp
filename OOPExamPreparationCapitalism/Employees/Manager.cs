using ExamPreparation_Capitalism.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamPreparation_Capitalism.Departments;

namespace ExamPreparation_Capitalism.Employees
{
    public class Manager : Employee, IManage
    {
        private decimal salary;
        public Manager()
            : base()
        {
        }
        public Manager(string firstName, string lastName, PositionType position, 
            Company worksInCompany, Department worksInDepartment = null)
            : base(firstName, lastName, position, worksInCompany, worksInDepartment)
        {
        }
        public override decimal Salary
        {
            get
            {
                return this.WorksInDepartment.DefaultSalaryPercentage/100m * this.WorksInCompany.CEO.Salary;
            }
        }
        public void PaySalaries()
        {
            throw new NotImplementedException();
        }
        public void FireEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
        public void HireEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
