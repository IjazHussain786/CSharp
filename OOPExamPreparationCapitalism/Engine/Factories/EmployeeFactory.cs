using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamPreparation_Capitalism.Employees;
using ExamPreparation_Capitalism.Departments;

namespace ExamPreparation_Capitalism.Engine.Factories
{
    public class EmployeeFactory
    {
        public Employee CreateEmployee(string firstName, string lastName, PositionType position,
            Company worksInCompany, Department worksInDepartment = null)
        {
            switch (position)
            {
                case PositionType.Accountant:
                    return new Accountant(firstName, lastName, position, worksInCompany, worksInDepartment);
                case PositionType.ChiefTelephoneOfficer:
                    return new ChiefTelephoneOfficer(firstName, lastName, position, worksInCompany, worksInDepartment);
                case PositionType.CleaningLady:
                    return new CleaningLady(firstName, lastName, position, worksInCompany, worksInDepartment);
                case PositionType.Manager:
                    return new Manager(firstName, lastName, position, worksInCompany, worksInDepartment);
                case PositionType.Regular:
                    return new Regular(firstName, lastName, position, worksInCompany, worksInDepartment);
                case PositionType.Salesman:
                    return new Salesman(firstName, lastName, position, worksInCompany, worksInDepartment);
                default:
                    throw new ArgumentException("Position type not supported.");
            }
        }
    }
}
