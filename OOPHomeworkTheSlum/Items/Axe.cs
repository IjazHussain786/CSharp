using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSlum.Items
{
    public class Axe : Item
    {
        private const int AxeDefaultHealthEffect = 0;
        private const int AxeDefaultDefenseEffect = 0;
        private const int AxeDefaultAttackEffect = 75;
        public Axe(string id)
            : base(id, AxeDefaultHealthEffect, AxeDefaultDefenseEffect, AxeDefaultAttackEffect)
        {
        }
    }
}
