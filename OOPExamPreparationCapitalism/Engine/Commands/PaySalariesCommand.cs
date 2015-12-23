using ExamPreparation_Capitalism.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamPreparation_Capitalism.Engine.Exceptions;
using ExamPreparation_Capitalism.Departments;

namespace ExamPreparation_Capitalism.Engine.Commands
{
    class PaySalariesCommand : Command
    {
        private static List<string> visited = new List<string>();
        private static int depth = 0;
        private const decimal defaultDepartmentPercentage = 15;
        public PaySalariesCommand(IEngine appEngine) 
            : base(appEngine)
        {
        }
        public override void Execute(string[] commandArgs)
        {
            string companyName = commandArgs[1];
            var company = this.AppEngine.CompanyList.FirstOrDefault(c => c.CompanyName == companyName);
            if (company == null)
            {
                throw new AppException(string.Format("Company {0} does not exist", companyName));
            }
            foreach (var department in company.DepartmentList)
            {
                DetermineSalaryPrecentage(department);
            }
            company.CEO.CollectSalary();
            foreach (var department in company.DepartmentList)
            {
                foreach (var employee in department.DepartmentEmployees)
                {
                    employee.CollectSalary();
                }
            }
            PrintSalaryCollectedReport(company);
        }

        private void PrintSalaryCollectedReport(Company company)
        {
            foreach (var department in company.DepartmentList)
            {
                Console.WriteLine(department.TotalSalariesPaid);
            }
        }
        private void DetermineSalaryPrecentage(Department department)
        {
            if (visited.Contains(department.DepartmentName) == false)
            {
                visited.Add(department.DepartmentName);
                department.DefaultSalaryPercentage = defaultDepartmentPercentage - depth;
                if (department.SubDepartmentsList.Count == 0)
                {
                    return;
                }
                foreach (var subDepartment in department.SubDepartmentsList)
                {
                    depth++;
                    DetermineSalaryPrecentage(subDepartment);
                    depth--;
                }
            }
        }
    }
}
