using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleRPGGame.Items;

namespace SimpleRPGGame.Interfaces
{
    public interface ICollect
    {
        IEnumerable<Item> Inventory { get; }
        void AddItemToInventory(Item item);
    }
}
