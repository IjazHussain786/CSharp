using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultimediaShop.MultimediaItems;

namespace MultimediaShop.Interfaces
{
    public interface ISale
    {
        IItem ItemSold { get; }
        DateTime DateOfPurchase { get; }
    }
}
