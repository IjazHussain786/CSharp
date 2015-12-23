using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPGGame
{
    public abstract class GameObject
    {
        private Position position;
        private char objectSymbol;
        protected GameObject(Position position, char objectSymbol)
        {
            this.Position = position;
            this.ObjectSymbol = objectSymbol;
        }
        public Position Position
        {
            get
            {
                return this.position;
            }
            set
            {
                if (value.X < 0 || value.Y < 0 )
                {
                    throw new ArgumentOutOfRangeException("position", "Specified coordinates are outside map.");
                }
                this.position = value;
            }
        }
        public char ObjectSymbol
        {
            get
            {
                return this.objectSymbol;
            }
            set
            {
                if (char.IsUpper(value) == false)
                {
                    throw new ArgumentOutOfRangeException("objectSymbol", "Object symbol must be upper case.");
                }
                this.objectSymbol = value;
            }
        }
    }
}
