using Huy_Phuong.Interfaces;
using System;
using System.Threading;
using System.Globalization;

namespace Huy_Phuong.Engine.Commands
{
    public class AddPerformanceCommand : Command
    {
        private const string PerformanceStartTimeFormat = "dd.MM.yyyy HH:mm";
        
        public AddPerformanceCommand(IAppEngine appEngine) 
            : base(appEngine)
        {
        }

        public override string Execute(string[] parameters)
        {
            string[] commandArgs = parameters[1].Split(',');
            
            string theatreName = commandArgs[0].Trim();
            string performanceName = commandArgs[1].Trim();
            DateTime startDateTime = DateTime.ParseExact(commandArgs[2].Trim(), PerformanceStartTimeFormat,
                                    CultureInfo.InvariantCulture);
            TimeSpan duration = TimeSpan.Parse(commandArgs[3].Trim());
            decimal ticketPrice = decimal.Parse(commandArgs[4], NumberStyles.Float);
            
            this.AppEngine.PerformanceDatabase.AddPerformance(theatreName, performanceName, startDateTime, duration, ticketPrice);

            string actionResult = "Performance added";

            return actionResult;
        }
    }
}
