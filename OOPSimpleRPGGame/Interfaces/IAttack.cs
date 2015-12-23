using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleRPGGame.Characters;

namespace SimpleRPGGame.Interfaces
{
    public interface IAttack
    {
        int Damage { get; }
        void Attack(Character enemy);
    }
}
