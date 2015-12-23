using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamPreparation_Capitalism.Interfaces;
using ExamPreparation_Capitalism.Employees;
using ExamPreparation_Capitalism.Engine.Exceptions;

namespace ExamPreparation_Capitalism.Engine.Commands
{
    class CreateEmployeeCommand : Command
    {
        public CreateEmployeeCommand(IEngine appEngine) 
            : base(appEngine)
        {
        }
        public override void Execute(string[] commandArgs)
        {
            string employeeFirstName = commandArgs[1];
            string employeeLastName = commandArgs[2];
            PositionType position = (PositionType)Enum.Parse(typeof(PositionType), commandArgs[3]);
            string companyName = commandArgs[4];
            string departmentName = null;
            Company company = this.AppEngine.CompanyList.FirstOrDefault(c => c.CompanyName == companyName);
            if (company == null)
            {
                throw new AppException(string.Format("Company {0} does not exist", companyName));
            }
            bool employeeAlreadyExists = company.FullEmployeesList.
                Any(e => e.FirstName == employeeFirstName && e.LastName == employeeLastName);
            if (employeeAlreadyExists)
            {
                bool employeeAlreadyExistsInDirectList = company.DirectEmployeesList.
                Any(e => e.FirstName == employeeFirstName && e.LastName == employeeLastName);
                if (employeeAlreadyExistsInDirectList)
                {
                    throw new AppException(
                        string.Format("Employee {0} {1} already exists in {2} (no department)",
                        employeeFirstName, employeeLastName, companyName));
                }
                else
                {
                    var department = company.FullEmployeesList.
                    FirstOrDefault(e => e.FirstName == employeeFirstName && e.LastName == employeeLastName).WorksInDepartment;
                    throw new AppException(
                        string.Format("Employee {0} {1} already exists in {2} (in department {3})",
                        employeeFirstName, employeeLastName, companyName, department));

                }
            }
            if (commandArgs.Length == 6)
            {
                departmentName = commandArgs[5];
                var department = company.DepartmentList.FirstOrDefault(d => d.DepartmentName == departmentName);
                var employee = this.AppEngine.EmployeeFactory.
                    CreateEmployee(employeeFirstName, employeeLastName, position, company, department);
                company.FullEmployeesList.Add(employee);
                department.DepartmentEmployees.Add(employee);
            }
            else
            {
                var employee = this.AppEngine.EmployeeFactory.
                    CreateEmployee(employeeFirstName, employeeLastName, position, company);
                company.FullEmployeesList.Add(employee);
                company.DirectEmployeesList.Add(employee);
            }
        }
    }
}
