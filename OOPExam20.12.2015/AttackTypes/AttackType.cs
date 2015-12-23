using OOPExam20._12._2015.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam20._12._2015.AttackTypes
{
    public abstract class AttackType : IAttack
    {
        protected AttackType(int healthEffect, int damageEffect)
        {
            this.HealthEffect = healthEffect;
            this.DamageEffect = damageEffect;
        }
        public int DamageEffect { get; set; } //To multiply.
        public int HealthEffect { get; set; } //To divide.
    }
}
