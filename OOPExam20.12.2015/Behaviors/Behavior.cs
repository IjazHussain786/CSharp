using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPExam20._12._2015.Interfaces;

namespace OOPExam20._12._2015.Behaviors
{
    public abstract class Behavior : IBehavioural
    {
        protected Behavior(int healthBonus, int damageBonus, int healthMinus, int damageMinus)
        {
            this.IsTriggered = false;
            this.HealthBonus = healthBonus;
            this.DamageBonus = damageBonus;
            this.HealthMinus = healthMinus;
            this.DamageMinus = damageMinus;
        }
        public string ID { get; set; }
        public int DamageMinus { get; set; }
        public int HealthMinus { get; set; }
        public int DamageBonus { get; set; }
        public int HealthBonus { get; set; }
        public bool IsTriggered { get; set; }
        public int CyclesCount { get; set; }
    }
}
