using System;
using Huy_Phuong.Interfaces;

namespace Huy_Phuong.UI
{
    public class ConsoleRenderer : IRenderer
    {
        public void WriteLine(string message, params string[] parameters)
        {
            Console.WriteLine(message, parameters);
        }
    }
}
