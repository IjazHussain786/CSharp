using MultimediaShop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultimediaShop.Engine.Factories;

namespace MultimediaShop.Engine
{
    public sealed class AppEngine : IAppEngine
    {
        public AppEngine(ICommandManager commandManager)
        {
            this.CommandManager = commandManager;
            this.ItemFactory = new ItemFactory();
            this.Supplies = new Dictionary<IItem, int>();
        }

        public ItemFactory ItemFactory { get; private set; }
        public IDictionary<IItem, int> Supplies { get; private set; }
        public ICommandManager CommandManager { get; private set; }
        public bool IsRunning { get; set; }

        public void Run()
        {
            this.IsRunning = true;
            this.CommandManager.Engine = this;
            this.CommandManager.SeedCommands();

            do
            {
                string command = Console.ReadLine();

                try
                {
                    this.CommandManager.ProcessCommand(command);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (this.IsRunning);
        }
    }
}
