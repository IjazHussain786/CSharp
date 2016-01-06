using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultimediaShop.Interfaces;
using MultimediaShop.Engine.Commands;

namespace MultimediaShop.Engine
{
    public class CommandManager : ICommandManager
    {
        protected readonly Dictionary<string, Command> commandsByName;

        public CommandManager()
        {
            this.commandsByName = new Dictionary<string, Command>();
        }

        public IAppEngine Engine { get; set; }

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
            this.commandsByName["supply"] = new SupplyCommand(this.Engine);
            this.commandsByName["sell"] = new SellCommand(this.Engine);
            this.commandsByName["rent"] = new RentCommand(this.Engine);
            this.commandsByName["return-rented-item"] = new ReturnRentedItemCommand(this.Engine);
            this.commandsByName["report"] = new ReportCommand(this.Engine);
        }
    }
}
