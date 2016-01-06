using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultimediaShop.Interfaces;
using System.Globalization;
using MultimediaShop.Engine.Exceptions;
using MultimediaShop.ManagingSales;

namespace MultimediaShop.Engine.Commands
{
    public class SellCommand : Command
    {
        private const string DateTimeFormat = "dd-MM-yyyy";

        public SellCommand(IAppEngine appEngine)
            : base(appEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string id = commandArgs[1];
            var item = this.AppEngine.Supplies.FirstOrDefault(pair => pair.Key.ID == id).Key;
            var saleDate = ToDateTime(commandArgs[2]);
            if (item == null)
            {
                throw new ArgumentNullException(string.Format("No item {0} in supplies stock.", id));
            }
            
            if (this.AppEngine.Supplies[item] == 0)
            {
                throw new InsufficientSuppliesException("There are not enough supplies to sell this item.");
            }

            SalesManager.AddSale(item, saleDate);
            this.AppEngine.Supplies[item]--;
        }

        private static DateTime ToDateTime(string dateString)
        {
            DateTime saleDate = DateTime.ParseExact(dateString, DateTimeFormat, CultureInfo.InvariantCulture);
            return saleDate;
        }
    }
}
