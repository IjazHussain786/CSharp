using System;
using Huy_Phuong.Interfaces;
using System.Text;

namespace Huy_Phuong.Engine.Commands
{
    public class PrintAllPerformancesCommand : Command
    {
        private const string PerformanceStartTimeFormat = "dd.MM.yyyy HH:mm";
        
        public PrintAllPerformancesCommand(IAppEngine appEngine) 
            : base(appEngine)
        {
        }

        public override string Execute(string[] commandArgs)
        {
            var performances = AppEngine.PerformanceDatabase.ListAllPerformances();

            StringBuilder result = new StringBuilder();
            foreach (var performance in performances)
            {
                result.Append(performance.ToString());
                result.Append(", ");
            }

            result.Remove(result.Length - 2, 2); //Remove the last comma and space.

            return result.ToString();
        }
    }
}
