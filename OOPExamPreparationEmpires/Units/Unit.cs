using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Interfaces;

namespace Empires.Units
{
    public abstract class Unit : IProducible
    {
        private int productionDuration;
        private int productionQuantity;
        private int health;
        private int attackDamage;
        public Unit()
        {
        }
        public UnitType UnitType { get; set; }
        public int ProductionDuration
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
        public int Health
        {
            get
            {
                return this.health;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Health cannot be negative!");
                }
                this.health = value;
            }
        }
        public int AttackDamage
        {
            get
            {
                return this.attackDamage;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Health cannot be negative!");
                }
                this.attackDamage = value;
            }
        }
    }
}
