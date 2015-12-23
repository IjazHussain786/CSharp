using ExamPreparation_Capitalism.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPreparation_Capitalism
{
    public interface IEmployable
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        PositionType Position { get; set; }
        Company WorksInCompany { get; set; }
        decimal Salary { get; set; }
    }
}
