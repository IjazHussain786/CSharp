using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Units;
using Empires.Resources;
using Empires.Engine;
using Empires.Interfaces;

namespace Empires.Buildings
{
    public abstract class Building : IProduce
    {
        public readonly int CreatedAtTurn;
        private List<Unit> producibleUnits;
        private List<Resource> producibleResources;
        public Building()
        {
            this.CreatedAtTurn = GameEngine.TurnsPassed;
            this.producibleUnits = new List<Unit>();
            this.producibleResources = new List<Resource>();
        }
        public BuildingType BuildingType { get; set; }
        public int TurnsSinceCreated 
        {
            get 
            {
                return GameEngine.TurnsPassed - this.CreatedAtTurn;
            } 
        }
        public IEnumerable<Unit> ProducibleUnits
        {
            get { return this.producibleUnits; }
        }
        public IEnumerable<Resource> ProducibleResources
        {
            get { return this.producibleResources; }
        }
        public void AddProducibleUnit(Unit unit)
        {
            this.producibleUnits.Add(unit);
        }
        public void AddProducibleResource(Resource resource)
        {
            this.producibleResources.Add(resource);
        }
        public List<UnitType> CanProduceUnit()
        {
            List<UnitType> unitsToProduce = new List<UnitType>();
            if (this.TurnsSinceCreated > 0)
            {
                foreach (Unit unit in this.producibleUnits)
                {
                    if (this.TurnsSinceCreated % unit.ProductionDuration == 0 && this.TurnsSinceCreated > 0)
                    {
                        unitsToProduce.Add(unit.UnitType);
                    }
                }
            }
            return unitsToProduce;
        }
        public List<ResourceType> CanProduceResource()
        {
            List<ResourceType> resourcesToProduce = new List<ResourceType>();
            if (this.TurnsSinceCreated > 0)
            {
                foreach (Resource resource in this.producibleResources)
                {
                    if (this.TurnsSinceCreated % resource.ProductionDuration == 0 && this.TurnsSinceCreated > 0)
                    {
                        resourcesToProduce.Add(resource.ResourceType);
                    }
                }
            }
            return resourcesToProduce;
        }
    }
}
