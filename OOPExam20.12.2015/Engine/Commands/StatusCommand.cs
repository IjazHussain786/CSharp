using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPExam20._12._2015.Interfaces;
using OOPExam20._12._2015.Characters;

namespace OOPExam20._12._2015.Engine.Commands
{
    public class StatusCommand : Command
    {
        public StatusCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }
        public override void Execute(string[] commandArgs)
        {
            foreach (Blob blob in this.GameEngine.Blobs)
            {
                this.GameEngine.Renderer.WriteLine(blob.ToString());
            }
        }
    }
}
