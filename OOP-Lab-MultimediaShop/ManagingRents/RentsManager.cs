using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultimediaShop.Interfaces;

namespace MultimediaShop.ManagingRents
{
    public static class RentsManager
    {
        private static ISet<IRent> rents = new HashSet<IRent>();

        public static void AddRent(IItem item, DateTime rentDate, DateTime deadline)
        {
            rents.Add(new Rent(item, rentDate, deadline));
        }

        public static IEnumerable<IRent> Rents 
        { 
            get
            {
                return rents;
            }
        }

        public static IEnumerable<IRent> ReportOverdueRents()
        {
            var overdueRents = rents
                .Where(r => r.RentState == RentState.Overdue)
                .OrderBy(r => r.RentFine)
                .ThenBy(r => r.ItemRented.Title);
            return overdueRents;
        }
    }
}
