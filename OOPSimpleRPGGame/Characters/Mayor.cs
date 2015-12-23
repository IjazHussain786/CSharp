using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleRPGGame.Attributes;

namespace SimpleRPGGame.Characters
{
    [Enemy]
    class Mayor : Character
    {
        const int MayorDamage = 50;
        const int MayorHealth = 250;
        const char MayorSymbol = 'M';
        public Mayor(Position position, string name)
            : base(position, MayorSymbol, MayorDamage, MayorHealth, name)
        {
        }
    }
}
