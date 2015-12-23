using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPExam20._12._2015.Characters;
using OOPExam20._12._2015.Interfaces;
using OOPExam20._12._2015.Engine;

namespace OOPExam20._12._2015.Engine.Commands
{
    public class AttackCommand : Command
    {
        public AttackCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }
        public override void Execute(string[] commandArgs)
        {
            string attackerName = commandArgs[1];
            string targetName = commandArgs[2];
            Blob attackingBlob = this.GameEngine.Blobs.First(b => b.Name == attackerName);
            Blob targetBlob = this.GameEngine.Blobs.First(b => b.Name == targetName);
            this.ProcessBlobBattle(attackingBlob, targetBlob);
        }
        private void ProcessBlobBattle(Blob attackingBlob, Blob targetBlob)
        {
            bool canPerformBattle = attackingBlob.IsAlive && targetBlob.IsAlive;
            if (canPerformBattle == false)
            {
                throw new ArgumentException("Either attacking or target blob is already dead.");
            }
            attackingBlob.Attack(targetBlob);
            if (targetBlob.Health == 0)
            {
                targetBlob.IsAlive = false;
            }
        }
    }
}
