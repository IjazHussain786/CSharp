using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSlum.Items
{
    public class Pill : Bonus
    {
        private const int PillDefaultHealthEffect = 0;
        private const int PillDefaultDefenseEffect = 0;
        private const int PillDefaultAttackEffect = 100;
        private const int PillDefaultCountdownValue = 1;
        public Pill(string id)
            : base(id, PillDefaultHealthEffect, PillDefaultDefenseEffect, PillDefaultAttackEffect)
        {
            this.Countdown = PillDefaultCountdownValue;
        }
    }
}
