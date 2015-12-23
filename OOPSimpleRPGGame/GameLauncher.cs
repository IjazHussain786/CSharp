using SimpleRPGGame.Interfaces;
using SimpleRPGGame.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleRPGGame.Engine;

namespace SimpleRPGGame
{
    public class GameLauncher
    {
        public static void Main()
        {
            IRenderer renderer = new ConsoleRenderer();
            IInputReader reader = new ConsoleInputReader();
            GameEngine engine = new GameEngine(reader, renderer);
            engine.Run();
        }
    }
}
