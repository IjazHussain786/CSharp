using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPExam20._12._2015.Characters;
using OOPExam20._12._2015.Behaviors;
using OOPExam20._12._2015.AttackTypes;

namespace OOPExam20._12._2015.Engine.Factories
{
    public class BlobFactory
    {
        public Blob CreateBlob(string name, int health, int damage, Behavior behaviorType, AttackType attackType)
        {
            return new Blob(name, health, damage, behaviorType, attackType);
        }
    }
}
