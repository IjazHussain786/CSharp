using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Interfaces;
using Empires.Buildings;
using Empires.Units;
using Empires.Resources;

namespace Empires.Engine.Commands
{
    public class BuildCommand : Command
    {
        public BuildCommand(IGameEngine gameEngine) 
            : base(gameEngine)
        {
        }
        public override void Execute(string[] commandArgs)
        {
            string buildingType = commandArgs[1];
            BuildingType type = (BuildingType)Enum.Parse(typeof(BuildingType), buildingType);
            var building = this.GameEngine.BuildingFactory.CreateBuilding(type);
            var swordsman = this.GameEngine.UnitFactory.CreateUnit(UnitType.Swordsman);
            var steel = this.GameEngine.ResourceFactory.CreateResource(ResourceType.Steel);
            building.AddProducibleUnit(swordsman);
            building.AddProducibleResource(steel);
            this.GameEngine.Buildings.Add(building);
        }
    }
}
