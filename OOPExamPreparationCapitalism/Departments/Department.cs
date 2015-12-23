using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamPreparation_Capitalism.Employees;

namespace ExamPreparation_Capitalism.Departments
{
    public class Department
    {
        private string name;
        private string companyName;
        private string mainDepartmentName;
        public Department(string name, string companyName, Manager manager, string mainDepartmentName = null)
        {
            this.DepartmentName = name;
            this.DepartmentOfCompany = companyName;
            this.DepartmentEmployees = new List<Employee>();
            this.DepartmentManager = manager;
            this.SubDepartmentsList = new List<Department>();
            this.MainDepartmentName = mainDepartmentName;
        }
        public string DepartmentName
        {
            get
            {
                return this.name;
            }
            set
            {
                value = value.Trim();
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Department Name", "Department name should not be empty!");
                }
                if (value.Length > 30)
                {
                    throw new ArgumentException("Department Name", "Department name should be no more than 30 letters!");
                }
                this.name = value;
            }
        }
        public string DepartmentOfCompany
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
        public IList<Employee> DepartmentEmployees { get; set; }
        public Manager DepartmentManager { get; set; }
        public IList<Department> SubDepartmentsList { get; set; }
        public string MainDepartmentName
        {
            get
            {
                return this.mainDepartmentName;
            }
            set
            {
                if (value != null)
                {
                    value = value.Trim();
                    if (value == String.Empty)
                    {
                        throw new ArgumentException("Main Department Name", "Main department name should not be empty!");
                    }
                    if (value.Length > 30)
                    {
                        throw new ArgumentException("Main Department Name", "Main department name should be no more than 30 letters!");
                    }
                }
                this.mainDepartmentName = value;
            }
        }
        public decimal DefaultSalaryPercentage { get; set; }
        public decimal TotalSalariesPaid { get; set; }
    }
}
