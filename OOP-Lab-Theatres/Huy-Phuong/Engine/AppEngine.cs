using System;
using System.Threading;
using System.Globalization;
using Huy_Phuong.Engine.Commands;
using System.Linq;
using Huy_Phuong.Data;
using Huy_Phuong.Interfaces;
using Huy_Phuong.Exceptions;

namespace Huy_Phuong.Engine
{
    public class AppEngine : IAppEngine
    {
        private readonly IRenderer renderer;
        private readonly IInputHandler inputHandler;
        private readonly ICommandManager commandManager;
        
        public AppEngine(ICommandManager commandManager, IPerformanceDatabase performanceDatabase,
            IRenderer renderer, IInputHandler inputHandler)
        {
            this.commandManager = commandManager;
            this.PerformanceDatabase = performanceDatabase;
            this.renderer = renderer;
            this.inputHandler = inputHandler;
        }

        public IPerformanceDatabase PerformanceDatabase { get; private set; }

        public bool IsRunning { get; set; }

        public virtual void Run()
        {
            this.IsRunning = true;
            this.commandManager.Engine = this;
            this.commandManager.SeedCommands();

            do
            {
                string command = this.inputHandler.ReadLine();

                if (command == null)
                {
                    // The end of the input is reached
                    return;
                }

                if (command != string.Empty)
                {
                    try
                    {
                        string actionResult = this.commandManager.ProcessCommand(command);
                        this.renderer.WriteLine(actionResult);
                    }
                    catch (TheaterException ex)
                    {
                        this.renderer.WriteLine(ex.Message);
                    }
                    catch (NotSupportedException ex)
                    {
                        this.renderer.WriteLine(ex.Message);
                    }
                }
            }
            while (this.IsRunning);
        }
    }
}