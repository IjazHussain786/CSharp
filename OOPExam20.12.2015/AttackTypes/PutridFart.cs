using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam20._12._2015.AttackTypes
{
    public class PutridFart : AttackType
    {
        private const int PutridFartHealthEffect = 1; //To divide.
        private const int PutridFartDamageEffect = 1; //To multiply.
        public PutridFart()
            : base(PutridFartHealthEffect, PutridFartDamageEffect)
        {
        }
    }
}
