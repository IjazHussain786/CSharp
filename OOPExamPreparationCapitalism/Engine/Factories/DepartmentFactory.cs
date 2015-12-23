using ExamPreparation_Capitalism.Departments;
using ExamPreparation_Capitalism.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPreparation_Capitalism.Engine.Factories
{
    public class DepartmentFactory
    {
        public Department CreateDepartment(string departmentName, string companyName, Manager manager)
        {
            return new Department(departmentName, companyName, manager);
        }
    }
}
