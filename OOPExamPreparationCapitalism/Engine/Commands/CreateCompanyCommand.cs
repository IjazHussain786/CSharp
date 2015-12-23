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
    class CreateCompanyCommand : Command
    {
        public CreateCompanyCommand(IEngine appEngine) 
            : base(appEngine)
        {
        }
        public override void Execute(string[] commandArgs)
        {
            string companyName = commandArgs[1];
            string ceoFirstName = commandArgs[2];
            string ceoLastName = commandArgs[3];
            string salary = commandArgs[4];
            decimal ceoSalary = 0;
            if (decimal.TryParse(salary, out ceoSalary))
            {
            }
            else
            { 
                throw new ArgumentException("Salary value should be numeric.");
            }
            bool companyAlreadyExists = this.AppEngine.CompanyList.Any(company => company.CompanyName == companyName);
            if (companyAlreadyExists)
            {
                throw new AppException(string.Format("Company {0} already exists", companyName));
            }
            var companyCEO = this.AppEngine.CEOList.FirstOrDefault(ceo => ceo.FirstName == ceoFirstName && ceo.LastName == ceoLastName);
            if (companyCEO != null)
            {
                companyCEO.WorksInCompany = companyName;
                var company = this.AppEngine.CompanyFactory.CreateCompany(companyName, companyCEO);
                this.AppEngine.CompanyList.Add(company);
            }
            else
            {
                companyCEO = new CEO(ceoFirstName, ceoLastName, PositionType.CEO, companyName, ceoSalary);
                this.AppEngine.CEOList.Add(companyCEO);
                var company = this.AppEngine.CompanyFactory.CreateCompany(companyName, companyCEO);
                this.AppEngine.CompanyList.Add(company);
            }
        }
    }
}
