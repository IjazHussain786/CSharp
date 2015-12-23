using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamPreparation_Capitalism.Interfaces;
using ExamPreparation_Capitalism.Engine.Commands;

namespace ExamPreparation_Capitalism.Engine
{
    public class CommandManager : ICommandManager
    {
        protected readonly Dictionary<string, Command> commandsByName;
        public CommandManager()
        {
            this.commandsByName = new Dictionary<string, Command>();
        }
        public IEngine AppEngine { get; set; }
        public void ProcessCommand(string commandString)
        {
            string[] commandArgs = commandString.Split(' ');
            string commandName = commandArgs[0];
            if (!this.commandsByName.ContainsKey(commandName))
            {
                throw new NotSupportedException(string.Format("Command {0} does not exist.", commandName));
            }
            var command = this.commandsByName[commandName];
            command.Execute(commandArgs);
        }
        public virtual void SeedCommands()
        {
            this.commandsByName["create-company"] = new CreateCompanyCommand(this.AppEngine);
            this.commandsByName["create-department"] = new CreateDepartmentCommand(this.AppEngine);
            this.commandsByName["create-employee"] = new CreateEmployeeCommand(this.AppEngine);
            this.commandsByName["pay-salaries"] = new PaySalariesCommand(this.AppEngine);
            //this.commandsByName["show-employees"] = new ShowEmployeesCommand(this.AppEngine);
            //this.commandsByName["end"] = new EndCommand(this.AppEngine);
        }
    }
}
