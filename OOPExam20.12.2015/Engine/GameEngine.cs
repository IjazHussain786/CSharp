using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPExam20._12._2015.Interfaces;
using OOPExam20._12._2015.Characters;
using OOPExam20._12._2015.Engine.Factories;

namespace OOPExam20._12._2015.Engine
{
    public class GameEngine : IGameEngine
    {
        private readonly IRenderer renderer;
        private readonly IInputHandler inputHandler;
        public GameEngine(ICommandManager commandManager, IInputHandler inputHandler, IRenderer renderer)
        {
            this.renderer = renderer;
            this.inputHandler = inputHandler;
            this.CommandManager = commandManager;
            this.BlobFactory = new BlobFactory();
            this.BehaviorFactory = new BehaviorFactory();
            this.AttackTypeFactory = new AttackTypeFactory();
            this.Blobs = new List<Blob>();
        }
        public IRenderer Renderer { get { return this.renderer; } }
        public IInputHandler InputHandler { get { return this.inputHandler; } }
        public BlobFactory BlobFactory { get; set; }
        public BehaviorFactory BehaviorFactory { get; set; }
        public AttackTypeFactory AttackTypeFactory { get; set; }
        public IList<Blob> Blobs { get; set; }
        public ICommandManager CommandManager { get; set; }
        public bool IsRunning { get; set; }
        public void Run()
        {
            this.IsRunning = true;
            this.CommandManager.Engine = this;
            this.CommandManager.SeedCommands();
            do
            {
                string command = this.inputHandler.ReadLine();
                try
                {
                    this.CommandManager.ProcessCommand(command);
                    this.UpdateBlobBehavior();
                }
                catch (Exception ex)
                {
                    this.renderer.WriteLine(ex.Message);
                }
            } 
            while (this.IsRunning);
        }
        private void UpdateBlobBehavior()
        {
            foreach (Blob blob in this.Blobs)
            {
                if (blob.Behavior.IsTriggered == true && blob.IsAlive == true)
                {
                    if (blob.Behavior.CyclesCount >= 1)
                    {
                        blob.UpdateBehaviorEffect();
                    }
                    blob.Behavior.CyclesCount++;
                }
            }
        }
    }
}
