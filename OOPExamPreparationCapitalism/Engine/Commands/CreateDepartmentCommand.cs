using ExamPreparation_Capitalism.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamPreparation_Capitalism.Engine.Exceptions;
using ExamPreparation_Capitalism.Employees;

namespace ExamPreparation_Capitalism.Engine.Commands
{
    class CreateDepartmentCommand : Command
    {
        public CreateDepartmentCommand(IEngine appEngine) 
            : base(appEngine)
        {
        }
        public override void Execute(string[] commandArgs)
        {
            string companyName = commandArgs[1];
            string departmentName = commandArgs[2];
            string managerFirstName = commandArgs[3];
            string managerLastName = commandArgs[4];
            string mainDepartmentName = null;
            var company = this.AppEngine.CompanyList.FirstOrDefault(c => c.CompanyName == companyName);
            if (company == null)
            {
                throw new AppException(string.Format("Company {0} does not exist", companyName));
            }
            bool departmentAlreadyExists = company.DepartmentList.Any(d => d.DepartmentName == departmentName);
            if (departmentAlreadyExists)
            {
                throw new AppException(string.Format("Department {0} already exists in {0}", departmentName, companyName));
            }
            var manager = (Manager)company.FullEmployeesList.
                FirstOrDefault(e => e.FirstName == managerFirstName && e.LastName == managerLastName);
            if (manager == null)
            {
                throw new AppException(string.Format
                    ("There is no employee called {0} {1} in company {2}", managerFirstName, managerLastName, companyName));
            }
            //var department = company.DepartmentList.FirstOrDefault(d => d.DepartmentName == departmentName);
            //bool isManagerEmployeeinDepartment = department.DepartmentEmployees.
            //    Any(m => m.FirstName == managerFirstName && m.LastName == managerLastName);
            //if (isManagerEmployeeinDepartment == false)
            //{
            //    throw new AppException(string.Format
            //            ("There is no employee called {0} {1} in department {2}",managerFirstName, managerLastName, departmentName));
            //}
            if (manager.Position != PositionType.Manager)
            {
                throw new AppException (string.Format
                    ("{0} {1} is not a manager (real position: {2})", 
                    managerFirstName, managerLastName, manager.Position.ToString()));
            }
            var department = this.AppEngine.DepartmentFactory.CreateDepartment(departmentName, companyName, manager);
            if (commandArgs.Length == 6)
            {
                mainDepartmentName = commandArgs[5];
                var mainDepartment = company.DepartmentList.FirstOrDefault(d => d.DepartmentName == mainDepartmentName);
                if (mainDepartment == null)
                {
                    throw new AppException(string.Format
                        ("There is no department {0} in {1}", mainDepartmentName, companyName));
                }
                department.MainDepartmentName = mainDepartmentName;
                mainDepartment.SubDepartmentsList.Add(department);
            }
            company.DepartmentList.Add(department);
        }
    }
}
