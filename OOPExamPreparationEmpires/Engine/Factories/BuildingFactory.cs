using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Buildings;

namespace Empires.Engine.Factories
{
    public class BuildingFactory
    {
        public Building CreateBuilding(BuildingType type)
        {
            switch (type)
            {
                case BuildingType.barracks:
                    return new Barracks();
                case BuildingType.archery:
                    return new Archery();
                default:
                    throw new NotSupportedException("Building type not supported.");
            }
        }
    }
}
