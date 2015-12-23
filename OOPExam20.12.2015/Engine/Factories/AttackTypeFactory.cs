using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPExam20._12._2015.AttackTypes;

namespace OOPExam20._12._2015.Engine.Factories
{
    public class AttackTypeFactory
    {
        public AttackType CreateAttackType(string type)
        {
            switch (type)
            {
                case "Blobplode":
                    return new Blobplode();
                case "PutridFart":
                    return new PutridFart();
                default:
                    throw new NotSupportedException("Attack type not supported.");
            }
        }
    }
}
