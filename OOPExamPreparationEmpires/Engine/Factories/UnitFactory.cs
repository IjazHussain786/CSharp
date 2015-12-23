using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Units;

namespace Empires.Engine.Factories
{
    public class UnitFactory
    {
        public Unit CreateUnit(UnitType type)
        {
            switch (type)
            {
                case UnitType.Archer:
                    return new Archer();
                case UnitType.Swordsman:
                    return new Swordsman();
                default:
                    throw new NotSupportedException("Unit type not supported.");
            }
        }
    }
}
