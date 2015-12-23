namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;
    using System.Linq;
    using MassEffect.GameObjects.Locations;
    using MassEffect.Exceptions;

    public class PlotJumpCommand : Command
    {
        public PlotJumpCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string shipName = commandArgs[1];
            string destinationName = commandArgs[2];
            IStarship ship = this.GameEngine.Starships.First(s => s.Name == shipName);
            base.ValidateAlive(ship);
            var previousLocation = ship.Location;
            StarSystem destination = this.GameEngine.Galaxy.StarSystems.First(g => g.Name == destinationName);
            if (previousLocation.Name == destinationName)
            {
                throw new ShipException(string.Format(Messages.ShipAlreadyInStarSystem, destinationName));
            }
            this.GameEngine.Galaxy.TravelTo(ship, destination);
            System.Console.WriteLine(Messages.ShipTraveled, shipName, previousLocation.Name, destinationName);
        }
    }
}
