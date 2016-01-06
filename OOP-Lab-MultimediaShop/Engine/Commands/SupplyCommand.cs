using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultimediaShop.Interfaces;

namespace MultimediaShop.Engine.Commands
{
    public class SupplyCommand : Command
    {
        public SupplyCommand(IAppEngine appEngine)
            : base(appEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string itemType = commandArgs[1];
            int itemQuantity = int.Parse(commandArgs[2]);
            string itemParameters = commandArgs[3];
            var item = this.AppEngine.ItemFactory.CreateItem(itemType, itemParameters);
            this.AddToSupplies(item, itemQuantity);
        }

        private void AddToSupplies(IItem item, int quantity)
        {
            if (this.AppEngine.Supplies.ContainsKey(item) == false)
            {
                this.AppEngine.Supplies[item] = 0;
            }

            this.AppEngine.Supplies[item] = this.AppEngine.Supplies[item] + quantity;
        }
    }
}
