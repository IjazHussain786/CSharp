using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleRPGGame.Attributes;

namespace SimpleRPGGame.Characters
{
    [Enemy]
    class Deputee : Character
    {
        const int DeputeeDamage = 100;
        const int DeputeeHealth = 300;
        const char DeputeeSymbol = 'D';
        public Deputee(Position position, string name)
            : base(position, DeputeeSymbol, DeputeeDamage, DeputeeHealth, name)
        {
        }
    }
}
