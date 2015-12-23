using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empires.Units
{
    public class Archer : Unit
    {
        private const int ArcherHealth = 25;
        private const int ArcherAttackDamage = 7;
        private const int ArcherProductionQuantity = 1;
        public Archer() : base()
        {
            this.UnitType = UnitType.Archer;
            this.Health = ArcherHealth;
            this.AttackDamage = ArcherAttackDamage;
            this.ProductionDuration = ProductionDurations.ArcherProductionDuration;
            this.ProductionQuantity = ArcherProductionQuantity;
        }
    }
}
