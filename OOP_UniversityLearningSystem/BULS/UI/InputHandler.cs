using Buls.Interfaces;
using System;

namespace Buls.UI
{
    public class InputHandler : IInputHandler
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
