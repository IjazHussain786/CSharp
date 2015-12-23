using ExamPreparation_Capitalism.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPreparation_Capitalism.Engine.Commands
{
    public abstract class Command
    {
        protected Command(IEngine appEngine)
        {
            this.AppEngine = appEngine;
        }
        public IEngine AppEngine { get; set; }
        public abstract void Execute(string[] commandArgs);
    }
}
