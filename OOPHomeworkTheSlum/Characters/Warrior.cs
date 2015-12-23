using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSlum.Interfaces;

namespace TheSlum.Characters
{
    public class Warrior : Character, IAttack
    {
        private const int WarriorDefaultHealth = 200;
        private const int WarriorDefaultDefense = 100;
        private const int WarriorDefaultAttack = 150;
        private const int WarriorDefaultRange = 2;
        public Warrior(string id, int x, int y, Team team)
            : base(id, x, y, WarriorDefaultHealth, WarriorDefaultDefense, team, WarriorDefaultRange)
        {
            this.AttackPoints = WarriorDefaultAttack;
        }
        public int AttackPoints { get; set; }
        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            var target = targetsList.FirstOrDefault(t => t.IsAlive == true && t.Team != this.Team);
            return target;
        }
        protected override void ApplyItemEffects(Items.Item item)
        {
            this.HealthPoints += item.HealthEffect;
            this.DefensePoints += item.DefenseEffect;
            this.AttackPoints += item.AttackEffect;
        }
        protected override void RemoveItemEffects(Items.Item item)
        {
            this.HealthPoints -= item.HealthEffect;
            this.DefensePoints -= item.DefenseEffect;
            this.AttackPoints -= item.AttackEffect;
            if (this.HealthPoints < 0)
            {
                this.HealthPoints = 1;
            }
        }
        public override void AddToInventory(Items.Item item)
        {
            this.Inventory.Add(item);
            this.ApplyItemEffects(item);
        }
        public override void RemoveFromInventory(Items.Item item)
        {
            this.Inventory.Remove(item);
            this.RemoveItemEffects(item);
        }
    }
}
