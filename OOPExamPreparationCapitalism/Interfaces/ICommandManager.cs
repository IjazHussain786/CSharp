using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPreparation_Capitalism.Interfaces
{
    public interface ICommandManager
    {
        IEngine AppEngine { get; set; }

        void ProcessCommand(string command);

        void SeedCommands();
    }
}
