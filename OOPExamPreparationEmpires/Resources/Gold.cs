using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires;

namespace Empires.Resources
{
    public class Gold : Resource
    {
        private const int GoldProductionQuantity = 5;
        public Gold() : base()
        {
            this.ResourceType = ResourceType.Gold;
            this.ProductionDuration = ProductionDurations.GoldProductionDuration;
            this.ProductionQuantity = GoldProductionQuantity;
        }
    }
}
