using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam20._12._2015.Behaviors
{
    public class AggresiveBehavior : Behavior
    {
        private const int AggresiveBehaviorHealthBonus = 0; //To add.
        private const int AggresiveBehaviorDamageBonus = 2; //To multiply.
        private const int AggresiveBehaviorHealthMinus = 0; //To substract.
        private const int AggresiveBehaviorDamageMinus = 5; //To substract.
        public AggresiveBehavior()
            : base(AggresiveBehaviorHealthBonus, AggresiveBehaviorDamageBonus, AggresiveBehaviorHealthMinus, AggresiveBehaviorDamageMinus)
        {
        }
    }
}
