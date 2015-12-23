using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleRPGGame;

namespace SimpleRPGGame.Interfaces
{
    public interface ICharacter : IAttack, IDie
    {
        string Name { get; }
        //Position Position { get; }
    }
}
