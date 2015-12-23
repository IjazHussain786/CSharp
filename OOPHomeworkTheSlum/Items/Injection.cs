using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSlum.Items
{
    public class Injection : Bonus
    {
        private const int InjectionDefaultHealthEffect = 200;
        private const int InjectionDefaultDefenseEffect = 0;
        private const int InjectionDefaultAttackEffect = 0;
        private const int InjectionDefaultCountdownValue = 3;
        public Injection(string id)
            : base(id, InjectionDefaultHealthEffect, InjectionDefaultDefenseEffect, InjectionDefaultAttackEffect)
        {
            this.Countdown = InjectionDefaultCountdownValue;
        }
    }
}
