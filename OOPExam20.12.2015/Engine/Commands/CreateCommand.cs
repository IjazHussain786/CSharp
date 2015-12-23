using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPExam20._12._2015.Interfaces;
using OOPExam20._12._2015.Engine;
using OOPExam20._12._2015.Characters;

namespace OOPExam20._12._2015.Engine.Commands
{
    public class CreateCommand : Command
    {
        public CreateCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }
        public override void Execute(string[] commandArgs)
        {
            string blobName = commandArgs[1];
            int blobHealth = int.Parse(commandArgs[2]);
            int blobDamage = int.Parse(commandArgs[3]);
            string behaviorType = commandArgs[4];
            string attackType = commandArgs[5];
            bool blobAlreadyExists = this.GameEngine.Blobs.Any(b => b.Name == blobName);
            if (blobAlreadyExists)
            {
                throw new ArgumentException("Blob with that name already created.");
            }
            var behavior = this.GameEngine.BehaviorFactory.CreateBehavior(behaviorType);
            var attack = this.GameEngine.AttackTypeFactory.CreateAttackType(attackType);
            var blob = this.GameEngine.BlobFactory.CreateBlob(blobName, blobHealth, blobDamage, behavior, attack);
            this.GameEngine.Blobs.Add(blob);
        }
    }
}
