using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPExam20._12._2015.Interfaces;
using OOPExam20._12._2015.Engine;

namespace OOPExam20._12._2015.Engine.Commands
{
    public abstract class Command
    {
        protected Command(IGameEngine gameEngine)
        {
            this.GameEngine = gameEngine;
        }
        public IGameEngine GameEngine { get; set; }
        public abstract void Execute(string[] commandArgs);
    }
}
