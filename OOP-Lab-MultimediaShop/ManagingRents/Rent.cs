using MultimediaShop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultimediaShop.MultimediaItems;

namespace MultimediaShop.ManagingRents
{
    public class Rent : IRent
    {
        private const int DefaultRentPeriodInDays = 30;
        private IItem itemRented;

        public Rent(IItem itemRented, DateTime dateOfRent, DateTime itemReturnDeadline)
        {
            this.ItemRented = itemRented;
            this.DateOfRent = dateOfRent;
            this.ItemReturnDeadline = itemReturnDeadline;
            this.DateOfReturn = null;
        }

        public Rent(IItem itemRented, DateTime dateOfRent)
            : this(itemRented, dateOfRent, DateTime.Now.AddDays(DefaultRentPeriodInDays))
        {
        }
        
        public Rent(IItem itemRented)
            : this(itemRented, DateTime.Now, DateTime.Now.AddDays(DefaultRentPeriodInDays))
        {
        }
        
        public IItem ItemRented
        {
            get
            {
                return this.itemRented;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Item to be rented cannot be empty.");
                }
                this.itemRented = value;
            }
        }

        public RentState RentState
        {
            get
            {
                var now = DateTime.Now;

                if (this.DateOfReturn != null)
                {
                    return RentState.Returned;
                }
                else if (now > this.ItemReturnDeadline)
                {
                    return RentState.Overdue;
                }
                else
                {
                    return RentState.Rented;
                }
            }
        }
        public DateTime DateOfRent { get; private set; }
        public DateTime ItemReturnDeadline { get; private set; }
        public DateTime? DateOfReturn { get; private set; }

        public decimal RentFine
        {
            get
            {
                if (this.RentState == RentState.Overdue)
                {
                    var now = DateTime.Now;
                    decimal fine = (now - this.ItemReturnDeadline).Days * (this.ItemRented.Price * 0.01m);
                    return fine;
                }
                else
                {
                    return 0m;
                }
            }
        }

        public void ReturnItem()
        {
            this.DateOfReturn = DateTime.Now;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(string.Format("- {0} {1}", this.GetType().Name, this.RentState));
            result.AppendLine(this.ItemRented.ToString());
            result.AppendLine(string.Format("Rent fine: {0:F2}", this.RentFine));

            return result.ToString();
        }
    }
}
