using MassEffect.GameObjects.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassEffect.GameObjects.Projectiles;

namespace MassEffect.GameObjects.Ships
{
    public class Frigate : Starship
    {
        private int projectilesFired; 
        public Frigate(string name, int health, int shields, int damage, int fuel, StarSystem location)
             : base(name, health, shields, damage, fuel, location)
        {
        }
        public Frigate(string name, StarSystem location)
            : base(name, location)
        {
        }
        public override Interfaces.IProjectile ProduceAttack()
        {
            projectilesFired++;
            return new ShieldReaver(this.Damage);
        }
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            if (this.Health > 0)
            {
                output.AppendLine(base.ToString());
                output.AppendLine(string.Format("-Projectiles fired:  {0}", this.projectilesFired));
            }
            return output.ToString();
        }
    }
}
