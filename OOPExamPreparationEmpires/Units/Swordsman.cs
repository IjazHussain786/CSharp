using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empires.Units
{
    public class Swordsman : Unit
    {
        private const int SwordsmanHealth = 40;
        private const int SwordsmanAttackDamage = 13;
                private const int SwordsmanProductionQuantity = 1;
        public Swordsman()
            : base()
        {
            this.UnitType = UnitType.Swordsman;
            this.Health = SwordsmanHealth;
            this.AttackDamage = SwordsmanAttackDamage;
            this.ProductionDuration = ProductionDurations.SwordsmanProductionDuration;
            this.ProductionQuantity = SwordsmanProductionQuantity;
        }
    }
}
