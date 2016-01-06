using MultimediaShop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultimediaShop.MultimediaItems;

namespace MultimediaShop.ManagingSales
{
    public class Sale : ISale
    {
        private IItem itemSold;
        public Sale(IItem itemSold, DateTime dateOfPurchase)
        {
            this.ItemSold = itemSold;
            this.DateOfPurchase = dateOfPurchase;
        }

        public Sale(IItem itemSold)
            : this(itemSold, DateTime.Now)
        {
        }

        public IItem ItemSold
        {
            get 
            { 
                return this.itemSold; 
            }
            private set 
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Item to be sold cannot be empty.");
                }
                this.itemSold = value;
            }
        }

        public DateTime DateOfPurchase { get; private set; }

        public override string ToString()
        {
            return string.Format("- {0} {1}\n{2}",
                this.GetType().Name, this.DateOfPurchase, this.ItemSold);
        }
    }
}
