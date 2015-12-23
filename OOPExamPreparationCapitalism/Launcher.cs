using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamPreparation_Capitalism.Interfaces;
using ExamPreparation_Capitalism.Engine;

namespace ExamPreparation_Capitalism
{
    public class Launcher
    {
        static void Main()
        {
            ICommandManager commandManager = new CommandManager();
            IEngine engine = new AppEngine(commandManager);
            engine.Run();
        }
    }
}
