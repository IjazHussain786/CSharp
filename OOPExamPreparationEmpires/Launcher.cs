using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Interfaces;
using Empires.Engine;

namespace Empires
{
    class Launcher
    {
        static void Main()
        {
            ICommandManager commandManager = new CommandManager();
            IGameEngine engine = new GameEngine(commandManager);
            engine.Run();
        }
    }
}
