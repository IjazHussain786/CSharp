using ExamPreparation_Capitalism.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamPreparation_Capitalism;

namespace ExamPreparation_Capitalism.Employees
{
    public abstract class Employee : IEmployable
    {
        private const decimal MinimalWage = 0;
        private string firstName;
        private string lastName;
        private decimal salary;
        private Company worksInCompany;
        private decimal salariesPaid;
        public Employee()
        {
        }
        public Employee(string firstName, string lastName, PositionType position, 
            Company worksInCompany, Department worksInDepartment = null)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Position = position;
            this.WorksInCompany = worksInCompany;
            this.WorksInDepartment = worksInDepartment; 
        }
        public Department WorksInDepartment { get; set; }
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                value = value.Trim();
                char[] temp = value.ToLower().ToCharArray();
                temp[0] = char.ToUpper(temp[0]);
                value = string.Join("", temp);
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Employee First Name", "First name should not be empty!");
                }
                if (value.Length < 2)
                {
                    throw new ArgumentException("Employee First Name", "First name should be at least two letters!");
                }
                if (value.Length > 20)
                {
                    throw new ArgumentException("Employee First Name", "First name should be no more than 20 letters!");
                }
                foreach (char letter in value)
                {
                    if (char.IsLetter(letter) == false)
                    {
                        throw new ArgumentException("Employee First Name", "First name should contain letters only!");
                    }
                }
                this.firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                value = value.Trim();
                char[] temp = value.ToLower().ToCharArray();
                temp[0] = char.ToUpper(temp[0]);
                value = string.Join("", temp);
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Employee Last Name", "Last name should not be empty!");
                }
                if (value.Length < 2)
                {
                    throw new ArgumentException("Employee Last Name", "Last name should be at least two letters!");
                }
                if (value.Length > 20)
                {
                    throw new ArgumentException("Employee Last Name", "Last name should be no more than 20 letters!");
                }
                foreach (char letter in value)
                {
                    if (char.IsLetter(letter) == false)
                    {
                        throw new ArgumentException("Employee Last Name", "Last name should contain letters only!");
                    }
                }
                this.lastName = value;
            }
        }
        public PositionType Position { get; set; }
        public Company WorksInCompany { get; set; }
        public virtual decimal Salary
        {
            get
            {
                return this.salary;
            }
            set
            {
                if (value < MinimalWage)
                {
                    throw new ArgumentException
                        ("Salary value", string.Format("Salary cannot be less than {0} (Minimal wage)", MinimalWage));
                }
                this.salary = value;
            }
        }
        public decimal SalariesPaid 
        {
            get
            {
                return this.salariesPaid;
            }
        }
        public void CollectSalary()
        {
            this.salariesPaid = this.salariesPaid + this.Salary;
            this.WorksInDepartment.TotalSalariesPaid = this.WorksInDepartment.TotalSalariesPaid + this.salariesPaid;
        }
    }
}
