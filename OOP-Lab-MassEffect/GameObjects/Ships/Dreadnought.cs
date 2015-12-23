using MassEffect.GameObjects.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassEffect.GameObjects.Projectiles;

namespace MassEffect.GameObjects.Ships
{
    class Dreadnought : Starship
    {
        public Dreadnought(string name, int health, int shields, int damage, int fuel, StarSystem location)
             : base(name, health, shields, damage, fuel, location)
        {
        }
        public Dreadnought(string name, StarSystem location)
            : base(name, location)
        {
        }
        public override Interfaces.IProjectile ProduceAttack()
        {
            return new Laser(this.Shields / 2 + this.Damage);
        }

        public override void RespondToAttack(Interfaces.IProjectile attack)
        {
            this.Shields = this.Shields + 50;
            base.RespondToAttack(attack);
            this.Shields = this.Shields - 50;
        }
    }
}
