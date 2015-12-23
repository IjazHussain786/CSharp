using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPExam20._12._2015.Interfaces;

namespace OOPExam20._12._2015.Engine.Commands
{
    public class DropCommand : Command
    {
        public DropCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }
        public override void Execute(string[] commandArgs)
        {
            this.GameEngine.IsRunning = false;
        }
    }
}
