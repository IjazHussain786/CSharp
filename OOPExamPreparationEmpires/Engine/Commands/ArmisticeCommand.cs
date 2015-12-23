using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Interfaces;

namespace Empires.Engine.Commands
{
    class ArmisticeCommand : Command
    {
        public ArmisticeCommand(IGameEngine gameEngine) 
            : base(gameEngine)
        {
        }
        public override void Execute(string[] commandArgs)
        {
            this.GameEngine.IsRunning = false;
        }
    }
}
