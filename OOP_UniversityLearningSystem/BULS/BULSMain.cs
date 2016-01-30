using Buls.Core;
using Buls.Interfaces;
using Buls.Data;
using Buls.UI;
using System.Reflection;

namespace Buls
{
    public class BULSMain
    {
        public static void Main()
        {
            IBangaloreUniversityData dataBase = new BangaloreUniversityData();
            IRenderer renderer = new ConsoleRenderer();
            IInputHandler inputHandler = new InputHandler();
            BangaloreUniversityEngine engine = new BangaloreUniversityEngine(dataBase, renderer, inputHandler);
            engine.Run();
        }
    }
}