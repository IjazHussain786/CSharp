using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultimediaShop.Engine.Factories;

namespace MultimediaShop.Interfaces
{
    public interface IAppEngine
    {
        ItemFactory ItemFactory { get; }
        IDictionary<IItem, int> Supplies { get; }
        ICommandManager CommandManager { get; }
        bool IsRunning { get; set; }
        void Run();
    }
}
