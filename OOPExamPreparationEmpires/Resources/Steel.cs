using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires;

namespace Empires.Resources
{
    public class Steel : Resource
    {
        private const int SteelProductionQuantity = 10;
        public Steel()
            : base()
        {
            this.ResourceType = ResourceType.Steel;
            this.ProductionDuration = ProductionDurations.SteelProductionDuration;
            this.ProductionQuantity = SteelProductionQuantity;
        }
    }
}
