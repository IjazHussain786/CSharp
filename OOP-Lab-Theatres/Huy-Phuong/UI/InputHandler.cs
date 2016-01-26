using System;
using Huy_Phuong.Interfaces;

namespace Huy_Phuong.UI
{
    public class InputHandler : IInputHandler
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
