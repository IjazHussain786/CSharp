using Huy_Phuong.Interfaces;
using Huy_Phuong.Engine;
using Huy_Phuong.Data;
using Huy_Phuong.UI;

namespace Huy_Phuong
{
    public class TheatresMain
    {
        public static void Main()
        {
            ICommandManager commandManager = new CommandManager();
            IPerformanceDatabase performanceDatabase = new PerformanceDatabase();
            IRenderer renderer = new ConsoleRenderer();
            IInputHandler inputHandler = new InputHandler();
            IAppEngine engine = new AppEngine(commandManager, performanceDatabase, renderer, inputHandler);
            engine.Run();
        }
    }
}
