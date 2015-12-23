using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPExam20._12._2015.Characters;
using OOPExam20._12._2015.Engine.Factories;

namespace OOPExam20._12._2015.Interfaces
{
    public interface IGameEngine
    {
        BlobFactory BlobFactory { get; }
        BehaviorFactory BehaviorFactory { get; }
        AttackTypeFactory AttackTypeFactory { get; }
        IList<Blob> Blobs { get; }
        ICommandManager CommandManager { get; }
        IRenderer Renderer { get; }
        IInputHandler InputHandler { get; }
        bool IsRunning { get; set; }
        void Run();
    }
}
