using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPGGame.Items
{
    class HealingPotion : Item
    {
        private int healthRestore;
        const char PotionSymbol = 'H';
        public HealingPotion(Position position, int healthRestore)
            : base(position, PotionSymbol)
        {
            this.healthRestore = healthRestore;
        }
        public int HealthRestore
        {
            get
            {
                return this.healthRestore;
            }
        }
    }
}
