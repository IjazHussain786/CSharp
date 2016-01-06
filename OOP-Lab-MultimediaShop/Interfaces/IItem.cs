using MultimediaShop.MultimediaItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultimediaShop.Interfaces
{
    public interface IItem
    {
        string ID { get; }
        string Title { get; }
        decimal Price { get; }
        IList<string> Genres { get; }
    }
}
