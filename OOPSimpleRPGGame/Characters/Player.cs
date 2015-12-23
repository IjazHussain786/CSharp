using SimpleRPGGame.Interfaces;
using SimpleRPGGame.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPGGame.Characters
{
    class Player : Character, IPlayer
    {
        private List<Item> inventory;
        public Player(Position position, char objectSymbol, int damage, int health, string name)
            : base(position, objectSymbol, damage, health, name)
        {
            this.inventory = new List<Item>();
        }
        public IEnumerable<Items.Item> Inventory
        {
            get 
            {
                return this.inventory;
            }
        }

        public void AddItemToInventory(Items.Item item)
        {
            this.inventory.Add(item);
        }

        public void Heal()
        {
            HealingPotion potion = (HealingPotion)this.inventory.FirstOrDefault();
            if (potion == null)
            {
                throw new InvalidOperationException("Inventory is empty!");
            }
            this.Health = this.Health + potion.HealthRestore;
            this.inventory.Remove(potion);
            Console.WriteLine("Healed!");
        }

        public void Move(string direction)
        {
            switch (direction)
            { 
                case "up":
                    this.Position = new Position(this.Position.X, this.Position.Y - 1);
                    break;
                case "left":
                    this.Position = new Position(this.Position.X - 1, this.Position.Y);
                    break;
                case "right":
                    this.Position = new Position(this.Position.X + 1, this.Position.Y);
                    break;
                case "down":
                    this.Position = new Position(this.Position.X, this.Position.Y + 1);
                    break;
                default:
                    throw new ArgumentException("Direction invalid.", "direction");
            }
        }
        public override string ToString()
        {
            return string.Format("{0} - Health: {1}", this.Name, this.Health);
        }
    }
}
