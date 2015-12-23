using MassEffect.GameObjects.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassEffect.GameObjects.Projectiles;

namespace MassEffect.GameObjects.Ships
{
    public class Cruiser : Starship
    {
        public Cruiser(string name, int health, int shields, int damage, int fuel, StarSystem location)
             : base(name, health, shields, damage, fuel, location)
        {
        }
        public Cruiser(string name, StarSystem location)
            : base(name, location)
        {
        }
        public override Interfaces.IProjectile ProduceAttack()
        {
             return new PenetrationShell(this.Damage);
        }
    }
}
