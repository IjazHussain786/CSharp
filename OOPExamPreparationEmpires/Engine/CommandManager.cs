using Empires.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Engine.Commands;

namespace Empires.Engine
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
        public virtual void SeedCommands()
        {
            this.commandsByName["build"] = new BuildCommand(this.Engine);
            this.commandsByName["skip"] = new SkipCommand(this.Engine);
            this.commandsByName["empire-status"] = new EmpireStatusCommand(this.Engine);
            this.commandsByName["armistice"] = new ArmisticeCommand(this.Engine);
        }
    }
}
