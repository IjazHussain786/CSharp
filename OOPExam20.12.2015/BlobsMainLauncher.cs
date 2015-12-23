using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPExam20._12._2015.Interfaces;
using OOPExam20._12._2015.Engine;
using OOPExam20._12._2015.UI;

namespace OOPExam20._12._2015
{
    public class BlobsMainLauncher
    {
        static void Main()
        {
            ICommandManager commandManager = new CommandManager();
            IRenderer renderer = new ConsoleRenderer();
            IInputHandler inputHandler = new InputHandler();
            IGameEngine engine = new GameEngine(commandManager, inputHandler, renderer);
            engine.Run();
        }
    }
}
