using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam20._12._2015.Behaviors
{
    public class InflatedBehavior : Behavior
    {
        private const int InflatedBehaviorHealthBonus = 50; //To add.
        private const int InflatedBehaviorDamageBonus = 1; //To multiply.
        private const int InflatedBehaviorHealthMinus = 10; //To substract.
        private const int InflatedBehaviorDamageMinus = 0; //To substract.
        public InflatedBehavior()
            : base(InflatedBehaviorHealthBonus, InflatedBehaviorDamageBonus, InflatedBehaviorHealthMinus, InflatedBehaviorDamageMinus)
        {
        }
    }
}
