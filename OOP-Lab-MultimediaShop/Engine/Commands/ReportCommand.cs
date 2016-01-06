using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultimediaShop.Interfaces;
using System.Globalization;
using MultimediaShop.ManagingRents;
using MultimediaShop.ManagingSales;

namespace MultimediaShop.Engine.Commands
{
    public class ReportCommand : Command
    {
        private const string DateTimeFormat = "dd-MM-yyyy";
        
        public ReportCommand(IAppEngine appEngine)
            : base(appEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string reportType = commandArgs[1];
            switch (reportType)
            {
                case "sales":
                    DateTime startDate = ToDateTime(commandArgs[2]);
                    decimal salesIncome = SalesManager.ReportSalesIncome(startDate);

                    Console.WriteLine(string.Format("{0:F2}", salesIncome));
                    break;
                case "rents":
                    var overdueRents = RentsManager.ReportOverdueRents();

                    Console.WriteLine(string.Join("\n", overdueRents));
                    break;
                default:
                    throw new ArgumentException("Invalid report type.");
            }
        }

        private static DateTime ToDateTime(string dateString)
        {
            return DateTime.ParseExact(dateString, DateTimeFormat, CultureInfo.InvariantCulture);
        }
    }
}
