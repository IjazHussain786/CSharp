using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSlum.Interfaces;

namespace TheSlum.Characters
{
    public class Mage : Character, IAttack
    {
        private const int MageDefaultHealth = 150;
        private const int MageDefaultDefense = 50;
        private const int MageDefaultAttack = 300;
        private const int MageDefaultRange = 5;
        public Mage(string id, int x, int y, Team team)
            : base(id, x, y, MageDefaultHealth, MageDefaultDefense, team, MageDefaultRange)
        {
            this.AttackPoints = MageDefaultAttack;
        }
        public int AttackPoints { get; set; }
        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            var target = targetsList.LastOrDefault(t => t.IsAlive == true && t.Team != this.Team);
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