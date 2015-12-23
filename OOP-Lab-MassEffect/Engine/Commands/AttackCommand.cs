namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;
    using System.Linq;
    using MassEffect.Exceptions;

    public class AttackCommand : Command
    {
        public AttackCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string attackerName = commandArgs[1];
            string targetName = commandArgs[2];
            IStarship attackingShip = this.GameEngine.Starships.First(s => s.Name == attackerName);
            IStarship targetShip = this.GameEngine.Starships.First(s => s.Name == targetName);
            this.ProcessStarshipbattle(attackingShip, targetShip);
            
        }

        private void ProcessStarshipbattle(IStarship attackingShip, IStarship targetShip)
        {
            base.ValidateAlive(attackingShip);
            base.ValidateAlive(targetShip);
            if (attackingShip.Location.Name != targetShip.Location.Name)
            {
                throw new ShipException(Messages.NoSuchShipInStarSystem);
            }
            IProjectile attack = attackingShip.ProduceAttack();
            targetShip.RespondToAttack(attack);
            System.Console.WriteLine(Messages.ShipAttacked, attackingShip.Name, targetShip.Name);
            if (targetShip.Shields < 0)
            {
                targetShip.Shields = 0;
            }
            if (targetShip.Health < 0)
            {
                targetShip.Health = 0;
                System.Console.WriteLine(Messages.ShipDestroyed, targetShip.Name);
            }
        }
    }
}
