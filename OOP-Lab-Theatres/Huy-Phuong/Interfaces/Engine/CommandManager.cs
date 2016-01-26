using Huy_Phuong.Interfaces;
using System.Collections.Generic;
using Huy_Phuong.Engine.Commands;
using System;

namespace Huy_Phuong.Engine
{
    public class CommandManager : ICommandManager
    {
        protected readonly Dictionary<string, Command> commandsByName;

        public CommandManager()
        {
            this.commandsByName = new Dictionary<string, Command>();
        }

        public IAppEngine Engine { get; set; }

        public virtual string ProcessCommand(string commandString)
        {
            string[] commandArgs = commandString.Split(new char[] {'(', ')'}, StringSplitOptions.RemoveEmptyEntries);
            string commandName = commandArgs[0];
            
            if (!this.commandsByName.ContainsKey(commandName))
            {
                throw new NotSupportedException(string.Format(
                    "Invalid command!", commandName));
            }

            var command = this.commandsByName[commandName];
            string actionResult = command.Execute(commandArgs);

            return actionResult;
        }

        public virtual void SeedCommands()
        {
            this.commandsByName["AddTheatre"] = new AddTheatreCommand(this.Engine);
            this.commandsByName["PrintAllTheatres"] = new PrintAllTheatresCommand(this.Engine);
            this.commandsByName["AddPerformance"] = new AddPerformanceCommand(this.Engine);
            this.commandsByName["PrintAllPerformances"] = new PrintAllPerformancesCommand(this.Engine);
            this.commandsByName["PrintPerformances"] = new PrintPerformancesCommand(this.Engine);
        }
    }
}
