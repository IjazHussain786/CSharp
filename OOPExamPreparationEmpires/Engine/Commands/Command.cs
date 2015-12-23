using Empires.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empires.Engine.Commands
{
    public abstract class Command
    {
        protected Command(IGameEngine gameEngine)
        {
            this.GameEngine = gameEngine;
        }
        public IGameEngine GameEngine { get; set; }
        public abstract void Execute(string[] commandArgs);
    }
}
