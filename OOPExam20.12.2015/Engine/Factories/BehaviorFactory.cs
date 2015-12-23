using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPExam20._12._2015.Behaviors;

namespace OOPExam20._12._2015.Engine.Factories
{
    public class BehaviorFactory
    {
        public Behavior CreateBehavior(string type)
        {
            switch (type)
            {
                case "Aggressive":
                    return new AggresiveBehavior();
                case "Inflated":
                    return new InflatedBehavior();
                default:
                    throw new NotSupportedException("Behavior type not supported.");
            }
        }
    }
}
