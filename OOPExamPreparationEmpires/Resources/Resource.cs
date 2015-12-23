using Empires.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empires.Resources
{
    public class Resource : IProducible
    {
        private int productionDuration;
        private int productionQuantity;
        public Resource()
        {
        }
        public ResourceType ResourceType { get; set; }
        public virtual int ProductionDuration
        {
            get
            {
                return this.productionDuration;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("ProductionDuration cannot be negative!");
                }
                this.productionDuration = value;    
            }
        }
        public int ProductionQuantity
        {
            get
            {
                return this.productionQuantity;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("ProductionQuantity cannot be negative!");
                }
                this.productionQuantity = value;
            }
        }
    }
}
