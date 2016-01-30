using System;
using Buls.Interfaces;

namespace Buls.UI
{
    public class ConsoleRenderer : IRenderer
    {
        public void WriteLine(string message, params string[] parameters)
        {
            Console.WriteLine(message, parameters);
        }
    }
}
