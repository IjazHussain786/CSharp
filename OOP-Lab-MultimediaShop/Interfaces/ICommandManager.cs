using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultimediaShop.Interfaces
{
    public interface ICommandManager
    {
        IAppEngine Engine { get; set; }

        void ProcessCommand(string command);

        void SeedCommands();
    }
}
