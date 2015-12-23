using ExamPreparation_Capitalism.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPreparation_Capitalism.Interfaces
{
    public interface IManage
    {
        void PaySalaries();
        void FireEmployee(Employee employee);
        void HireEmployee(Employee employee);
    }
}
