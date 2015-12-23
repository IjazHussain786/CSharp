using Empires.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Buildings;
using Empires.Units;
using Empires.Resources;
using Empires.Engine.Factories;

namespace Empires.Engine
{
    public sealed class GameEngine : IGameEngine
    {
        private static int turnsPassed;
        public GameEngine(ICommandManager commandManager)
        {
            this.CommandManager = commandManager;
            this.BuildingFactory = new BuildingFactory();
            this.UnitFactory = new UnitFactory();
            this.ResourceFactory = new ResourceFactory();
            this.Buildings = new List<Building>();
            this.Units = new Dictionary<string, int>();
            this.Resources = new Dictionary<string, int>();
        }
        public static int TurnsPassed
        {
            get { return turnsPassed; }
        }
        public BuildingFactory BuildingFactory { get; private set; }
        public UnitFactory UnitFactory { get; private set; }
        public ResourceFactory ResourceFactory { get; private set; }
        public IList<Building> Buildings { get; private set; }
        public Dictionary<string, int> Units { get; private set; }
        public Dictionary<string, int> Resources { get; private set; }
        public ICommandManager CommandManager { get; private set; }
        public bool IsRunning { get; set; }
        public void Run()
        {
            this.IsRunning = true;
            this.CommandManager.Engine = this;
            this.CommandManager.SeedCommands();
            this.InitializeResourcesDictionary(this.Resources);
            this.InitializeUnitsDictionary(this.Units);
            do
            {
                string command = Console.ReadLine();
                try
                {
                    this.CommandManager.ProcessCommand(command);
                    if (this.Buildings.Count > 0)
                    {
                        ProduceUnits();
                        ProduceResources();
                    }
                    turnsPassed++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (this.IsRunning);
        }

        private void InitializeUnitsDictionary(Dictionary<string, int> units)
        {
            units["Archer"] = 0;
            units["Swordsman"] = 0;
        }

        private void InitializeResourcesDictionary(Dictionary<string, int> resources)
        {
            resources["Gold"] = 0;
            resources["Steel"] = 0;
        }

        private void ProduceResources()
        {
            foreach (Building building in this.Buildings)
            {
                var producibleResources = building.CanProduceResource();
                if (producibleResources.Count > 0)
                {
                    foreach (var resourceType in producibleResources)
                    {
                        var resource = this.ResourceFactory.CreateResource(resourceType);
                        this.Resources[resourceType.ToString()] = 
                            this.Resources[resourceType.ToString()] + resource.ProductionQuantity;
                    }
                }
            }
        }
        private void ProduceUnits()
        {
            foreach (Building building in this.Buildings)
            {
                var producibelUnits = building.CanProduceUnit();
                if (producibelUnits.Count > 0)
                {
                    foreach (var unitType in producibelUnits)
                    {
                        var unit = this.UnitFactory.CreateUnit(unitType);
                        this.Units[unitType.ToString()] =
                            this.Units[unitType.ToString()] + unit.ProductionQuantity;
                    }
                }
            }
        }

    }
}
