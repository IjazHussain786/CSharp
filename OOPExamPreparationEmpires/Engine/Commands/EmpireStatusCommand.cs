using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Interfaces;

namespace Empires.Engine.Commands
{
    class EmpireStatusCommand : Command
    {
        public EmpireStatusCommand(IGameEngine gameEngine) 
            : base(gameEngine)
        {
        }
        public override void Execute(string[] commandArgs)
        {
            Console.WriteLine("Treasury:");
            int goldAmount = this.GameEngine.Resources["Gold"];
            int steelAmount = this.GameEngine.Resources["Steel"];
            int archerCount = this.GameEngine.Units["Archer"];
            int swordsmanCount = this.GameEngine.Units["Swordsman"];
            Console.WriteLine("--Gold: {0}", goldAmount);
            Console.WriteLine("--Steel: {0}", steelAmount);
            Console.WriteLine("Units:");
            Console.WriteLine("--Swordsman: {0}", swordsmanCount);
            Console.WriteLine("--Archer: {0}", archerCount);
        }
    }
}
