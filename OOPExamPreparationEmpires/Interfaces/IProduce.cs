using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Units;
using Empires.Resources;

namespace Empires.Interfaces
{
    public interface IProduce
    {
        List<UnitType> CanProduceUnit();
        List<ResourceType> CanProduceResource();
    }
}
