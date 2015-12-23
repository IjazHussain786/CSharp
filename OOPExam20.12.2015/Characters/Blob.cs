using OOPExam20._12._2015.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPExam20._12._2015.AttackTypes;
using OOPExam20._12._2015.Engine;

namespace OOPExam20._12._2015.Characters
{
    public class Blob : Character
    {
        private readonly int StartHealth;
        private readonly int StartDamage;
        public Blob(string name, int health, int damage, Behavior behaviorType, AttackType attackType)
            : base(name, health, damage)
        {
            this.Behavior = behaviorType;
            this.AttackType = attackType;
            this.StartHealth = health;
            this.StartDamage = damage;
        }
        public Behavior Behavior { get; set; }
        public AttackType AttackType { get; set; }
        public void Attack(Blob target)
        {
            this.ApplyAttackTypeEffect();
            if ((this.Health <= this.StartHealth / 2) && (this.Behavior.IsTriggered == false))
            {
                this.Behavior.IsTriggered = true;
                this.ApplyInitialBehaviorEffect();
            }
            int targetCurrentHealth = 0;
            if (this.AttackType is Blobplode)
            {
                targetCurrentHealth = target.Health - 2 * this.Damage;
            }
            else if (this.AttackType is PutridFart)
            {
                targetCurrentHealth = target.Health - this.Damage;
            }
            if (targetCurrentHealth < 0)
            {
                targetCurrentHealth = 0;
            }
            target.Health = targetCurrentHealth;
            if ((targetCurrentHealth <= target.StartHealth / 2) && (target.Behavior.IsTriggered == false))
            {
                target.Behavior.IsTriggered = true;
                target.ApplyInitialBehaviorEffect();
            }
        }
        private void ApplyInitialBehaviorEffect()
        {
            this.Damage = this.Damage * this.Behavior.DamageBonus;
            this.Health = this.Health + this.Behavior.HealthBonus;
        }
        private void ApplyAttackTypeEffect()
        {
            if (this.AttackType is Blobplode)
            {
                int healthEffect = this.Health - (this.Health / this.AttackType.HealthEffect);
                if (healthEffect < 1)
                {
                    healthEffect = 1;
                }
                this.Health = healthEffect;
            }
        }
        public void UpdateBehaviorEffect()
        {
            int currentDamage = this.Damage - this.Behavior.DamageMinus;
            if (currentDamage < this.StartDamage)
            {
                currentDamage = StartDamage;
            }
            this.Damage = currentDamage;
            int currentHealth = this.Health - this.Behavior.HealthMinus;
            if (currentHealth < 0)
            {
                currentHealth = 0;
            }
            this.Health = currentHealth;
            if (this.Health == 0)
            {
                this.IsAlive = false;
            }
        }
        public override string ToString()
        {
            string output = string.Empty;
            if (this.IsAlive)
            {
                output = string.Format("{0} {1}: {2} HP, {3} Damage", this.GetType().Name, this.Name, this.Health, this.Damage);
            }
            else
            {
                output = string.Format("{0} {1} KILLED", this.GetType().Name, this.Name);
            }
            return output;
        }
    }
}
