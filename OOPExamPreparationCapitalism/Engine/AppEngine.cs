using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamPreparation_Capitalism.Interfaces;
using ExamPreparation_Capitalism.Engine.Exceptions;
using ExamPreparation_Capitalism.Engine.Factories;

namespace ExamPreparation_Capitalism
{
    public sealed class AppEngine : IEngine
    {
        public AppEngine(ICommandManager commandManager)
        {
            this.CommandManager = commandManager;
            this.CompanyFactory = new CompanyFactory();
            this.DepartmentFactory = new DepartmentFactory();
            this.EmployeeFactory = new EmployeeFactory();
            this.CompanyList = new List<Company>();
            this.CEOList = new List<CEO>();
        }
        public CompanyFactory CompanyFactory { get; private set; }
        public DepartmentFactory DepartmentFactory { get; private set; }
        public EmployeeFactory EmployeeFactory { get; private set; }
        public IList<Company> CompanyList { get; private set; }
        public IList<CEO> CEOList { get; private set; }
        public ICommandManager CommandManager { get; set; }
        public bool IsRunning { get; set; }
        public void Run()
        {
            this.IsRunning = true;
            this.CommandManager.AppEngine = this;
            this.CommandManager.SeedCommands();
            do
            {
                string command = Console.ReadLine();

                try
                {
                    this.CommandManager.ProcessCommand(command);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } 
            while (this.IsRunning);
        }
    }
}
