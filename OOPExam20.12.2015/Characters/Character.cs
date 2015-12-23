using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam20._12._2015.Characters
{
    public abstract class Character
    {
        private string name;
        private int health;
        private int damage;
        protected Character(string name, int health, int damage)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
            this.IsAlive = true;
        }
        public string Name
       {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Character Name", "Name should not be empty!");
                }
                value = value.Trim();
                char[] temp = value.ToLower().ToCharArray();
                temp[0] = char.ToUpper(temp[0]);
                value = string.Join("", temp);
                if (value.Length < 2)
                {
                    throw new ArgumentException("Character Name", "Name should be at least two letters!");
                }
                if (value.Length > 20)
                {
                    throw new ArgumentException("Character Name", "Name should be no more than 20 letters!");
                }
                foreach (char letter in value)
                {
                    if (char.IsLetter(letter) == false)
                    {
                        throw new ArgumentException("Character Name", "Name should contain letters only!");
                    }
                }
                this.name = value;
            }
        }
        public int Health
        {
            get { return this.health; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Character health vlaue", "Character health cannot be negative!");
                }
                this.health = value;
            }
        }
        public int Damage
        {
            get { return this.damage; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Character damage vlaue", "Character damage cannot be negative!");
                }
                this.damage = value;
            }
        }
        public bool IsAlive { get; set; }
    }
}
