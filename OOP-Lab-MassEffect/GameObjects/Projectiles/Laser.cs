using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassEffect.GameObjects.Projectiles
{
    class Laser : Projectile
    {
        public Laser(int damage)
            : base(damage)
        {
        }
        public override void Hit(Interfaces.IStarship ship)
        {
            int actualDamage = 0;
            ship.Shields = ship.Shields - this.Damage;
            if (ship.Shields < 0)
            {
                actualDamage = Math.Abs(ship.Shields);
            }
            ship.Health = ship.Health - actualDamage;
        }
    }
}
