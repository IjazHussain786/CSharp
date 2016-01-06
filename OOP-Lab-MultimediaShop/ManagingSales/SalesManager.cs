using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultimediaShop.Interfaces;

namespace MultimediaShop.ManagingSales
{
    public static class SalesManager
    {
        private static ISet<ISale> sales = new HashSet<ISale>();

        public static void AddSale(IItem item, DateTime dateTime)
        {
            sales.Add(new Sale(item, dateTime));
        }

        public static decimal ReportSalesIncome(DateTime startDate)
        {
            decimal salesIncome = sales
                .Where(s => s.DateOfPurchase >= startDate)
                .Sum(s => s.ItemSold.Price);
            return salesIncome;
        }
    }
}
