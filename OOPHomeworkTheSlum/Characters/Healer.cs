using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSlum.Interfaces;

namespace TheSlum.Characters
{
    public class Healer : Character, IHeal
    {
        private const int HealerDefaultHealth = 75;
        private const int HealerDefaultDefense = 50;
        private const int HealerDefaultHealingPoints = 60;
        private const int HealerDefaultRange = 6;
        public Healer(string id, int x, int y, Team team)
            : base(id, x, y, HealerDefaultHealth, HealerDefaultDefense, team, HealerDefaultRange)
        {
            this.HealingPoints = HealerDefaultHealingPoints;
        }
        public int HealingPoints {get; set;}
        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            var target = targetsList.OrderBy(t => t.HealthPoints).
                FirstOrDefault(t => t.IsAlive == true && t.Team == this.Team && t.Id != this.Id);
            return target;
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
