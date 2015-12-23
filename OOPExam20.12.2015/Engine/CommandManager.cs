using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPExam20._12._2015.Interfaces;
using OOPExam20._12._2015.Engine.Commands;

namespace OOPExam20._12._2015.Engine
{
    public class CommandManager : ICommandManager
    {
        protected readonly Dictionary<string, Command> commandsByName;
        public CommandManager()
        {
            this.commandsByName = new Dictionary<string, Command>();
        }
        public IGameEngine Engine { get; set; }
        public void ProcessCommand(string commandString)
        {
            string[] commandArgs = commandString.Split(' ');
            string commandName = commandArgs[0];

            if (!this.commandsByName.ContainsKey(commandName))
            {
                throw new NotSupportedException(string.Format(
                    "Command {0} does not exist.", commandName));
            }
            var command = this.commandsByName[commandName];
            command.Execute(commandArgs);
        }
        public void SeedCommands()
        {
            this.commandsByName["create"] = new CreateCommand(this.Engine);
            this.commandsByName["attack"] = new AttackCommand(this.Engine);
            this.commandsByName["pass"] = new PassCommand(this.Engine);
            this.commandsByName["status"] = new StatusCommand(this.Engine);
            this.commandsByName["drop"] = new DropCommand(this.Engine);
        }
    }
}
