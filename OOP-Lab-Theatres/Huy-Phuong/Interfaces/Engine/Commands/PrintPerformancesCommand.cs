using System;
using Huy_Phuong.Interfaces;
using System.Text;

namespace Huy_Phuong.Engine.Commands
{
    public class PrintPerformancesCommand : Command
    {
        private const string PerformanceStartTimeFormat = "dd.MM.yyyy HH:mm";
        
        public PrintPerformancesCommand(IAppEngine appEngine) 
            : base(appEngine)
        {
        }

        public override string Execute(string[] commandArgs)
        {
            string theatre = commandArgs[1];

            var performances = AppEngine.PerformanceDatabase.ListPerformances(theatre);
            StringBuilder result = new StringBuilder();
            foreach (var performance in performances)
	        {
                result.Append("(" + performance.Name + ", " + performance.StartDateTime.ToString(PerformanceStartTimeFormat) + ")");
                result.Append(", ");
	        }

            result.Remove(result.Length - 2, 2); //Remove the last comma and space.
            
            return result.ToString();
        }
    }
}
