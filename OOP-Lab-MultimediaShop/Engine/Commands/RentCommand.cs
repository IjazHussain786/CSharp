using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultimediaShop.Interfaces;
using MultimediaShop.Engine.Exceptions;
using MultimediaShop.ManagingRents;
using System.Globalization;

namespace MultimediaShop.Engine.Commands
{
    public class RentCommand : Command
    {
        private const string DateTimeFormat = "dd-MM-yyyy";
        
        public RentCommand(IAppEngine appEngine)
            : base(appEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string id = commandArgs[1];
            var item = this.AppEngine.Supplies.FirstOrDefault(pair => pair.Key.ID == id).Key;
            var rentDate = ToDateTime(commandArgs[2]);
            var deadline = ToDateTime(commandArgs[3]);
            if (item == null)
            {
                throw new ArgumentNullException(string.Format("No item {0} in supplies stock.", id));
            }

            if (this.AppEngine.Supplies[item] == 0)
            {
                throw new InsufficientSuppliesException("There are not enough supplies to rent this item.");
            }

            RentsManager.AddRent(item, rentDate, deadline);
            this.AppEngine.Supplies[item]--;
        }

        private static DateTime ToDateTime(string dateString)
        {
            DateTime saleDate = DateTime.ParseExact(dateString, DateTimeFormat, CultureInfo.InvariantCulture);
            return saleDate;
        }
    }
}
