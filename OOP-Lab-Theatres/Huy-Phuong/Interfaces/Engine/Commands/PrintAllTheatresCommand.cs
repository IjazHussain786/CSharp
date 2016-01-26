using System;
using System.Text;
using Huy_Phuong.Interfaces;

namespace Huy_Phuong.Engine.Commands
{
    public class PrintAllTheatresCommand : Command
    {
        public PrintAllTheatresCommand(IAppEngine appEngine) 
            : base(appEngine)
        {
        }

        public override string Execute(string[] commandArgs)
        {
            var theatres = AppEngine.PerformanceDatabase.ListTheatres();
            StringBuilder result = new StringBuilder();
            foreach (var item in theatres)
            {
                result.Append(item);
                result.Append(", ");
            }

            result.Remove(result.Length - 2, 2); //Remove the last comma and space.

            return result.ToString();
        }
    }
}
