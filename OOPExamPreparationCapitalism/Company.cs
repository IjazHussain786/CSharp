using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamPreparation_Capitalism.Employees;
using ExamPreparation_Capitalism.Departments;

namespace ExamPreparation_Capitalism
{
    public class Company
    {
        private string companyName;
        public Company(string companyName, CEO ceo)
        {
            this.CompanyName = companyName;
            this.CEO = ceo;
            this.DirectEmployeesList = new List<Employee>();
            this.DepartmentList = new List<Department>();
            this.FullEmployeesList = new List<Employee>();
        }
        public string CompanyName
        {
            get
            {
                return this.companyName;
            }
            set
            {
                value = value.Trim();
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Company Name", "Company name should not be empty!");
                }
                if (value.Length > 30)
                {
                    throw new ArgumentException("Company Name", "Company name should be no more than 30 letters!");
                }
                this.companyName = value;
            }
        }
        public CEO CEO { get; set; }
        public IList<Employee> DirectEmployeesList { get; set; }
        public IList<Employee> FullEmployeesList { get; set; }
        public IList<Department> DepartmentList { get; set; }
    }
}
