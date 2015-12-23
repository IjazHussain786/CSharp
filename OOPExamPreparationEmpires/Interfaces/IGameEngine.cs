using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Units;
using Empires.Resources;
using Empires.Buildings;
using Empires.Engine.Factories;

namespace Empires.Interfaces
{
    public interface IGameEngine
    {
        BuildingFactory BuildingFactory { get; }
        UnitFactory UnitFactory { get; }
        ResourceFactory ResourceFactory { get; }
        IList<Building> Buildings { get; }
        Dictionary<string, int> Units { get; }
        Dictionary<string, int> Resources { get; }
        ICommandManager CommandManager { get; }
        bool IsRunning { get; set; }
        void Run();
    }
}
