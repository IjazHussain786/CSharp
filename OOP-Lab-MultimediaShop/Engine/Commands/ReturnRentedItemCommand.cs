using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultimediaShop.Interfaces;
using MultimediaShop.ManagingRents;
using System.Globalization;

namespace MultimediaShop.Engine.Commands
{
    public class ReturnRentedItemCommand : Command
    {
        private const string DateTimeFormat = "dd-MM-yyyy";

        public ReturnRentedItemCommand(IAppEngine appEngine)
            : base(appEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string id = commandArgs[1];
            var rent = RentsManager.Rents.FirstOrDefault(r => r.ItemRented.ID == id);
            var returnDate = ToDateTime(commandArgs[2]);
            if (rent == null)
            {
                throw new ArgumentNullException(string.Format("Item {0} does not exits in rent records.", id));
            }

            if (rent.RentState == RentState.Overdue)
            {
                Console.WriteLine("Rent is overdue. Fine due: {0}", rent.RentFine);
            }
            rent.ReturnItem();
            this.AppEngine.Supplies[rent.ItemRented]++;
        }

        private static DateTime ToDateTime(string dateString)
        {
            DateTime saleDate = DateTime.ParseExact(dateString, DateTimeFormat, CultureInfo.InvariantCulture);
            return saleDate;
        }
    }
}
