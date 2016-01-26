
namespace Huy_Phuong.Interfaces
{
    public interface IAppEngine
    {
        IPerformanceDatabase PerformanceDatabase { get; }

        bool IsRunning { get; set; }

        void Run();
    }
}
