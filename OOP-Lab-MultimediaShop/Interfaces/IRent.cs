using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultimediaShop.MultimediaItems;
using MultimediaShop.ManagingRents;

namespace MultimediaShop.Interfaces
{
    public interface IRent
    {
        IItem ItemRented { get; }
        RentState RentState { get; }
        DateTime DateOfRent { get; }
        DateTime ItemReturnDeadline { get; }
        DateTime? DateOfReturn { get; }
        decimal RentFine { get; }
        void ReturnItem();
    }
}
