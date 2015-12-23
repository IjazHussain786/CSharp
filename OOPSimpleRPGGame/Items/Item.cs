using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPGGame.Items
{
    public abstract class Item : GameObject
    {
        protected Item(Position position, char itemSymbol)
            : base(position, itemSymbol)
        {
            this.ItemState = Items.ItemState.Available;
        }
        public ItemState ItemState { get; set; }
    }
}
