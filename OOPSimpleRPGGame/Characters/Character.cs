using SimpleRPGGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPGGame.Characters
{
    public abstract class Character : GameObject, ICharacter
    {
        public Character(Position position, char objectSymbol, int damage, int health, string name)
            : base(position, objectSymbol)
        {
            this.Damage = damage;
            this.Health = health;
            this.Name = name;
        }
        public string Name
        {
            get; private set;
        }
        public int Damage
        {
            get; private set;
        }

        public void Attack(Character enemy)
        {
            enemy.Health = enemy.Health - this.Damage;
        }

        public int Health
        {
            get; set;
        }

        public void Die()
        {
            throw new NotImplementedException();
        }
    }
}
