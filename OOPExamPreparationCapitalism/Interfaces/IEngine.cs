using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamPreparation_Capitalism.Engine.Factories;

namespace ExamPreparation_Capitalism.Interfaces
{
    public interface IEngine
    {
        CompanyFactory CompanyFactory { get; }
        DepartmentFactory DepartmentFactory { get; }
        EmployeeFactory EmployeeFactory { get; }
        IList<Company> CompanyList { get; }
        IList<CEO> CEOList { get; }
        ICommandManager CommandManager { get; }
        bool IsRunning { get; set; }
        void Run();
    }
}
