
namespace Huy_Phuong.Interfaces
{
    public interface ICommandManager
    {
        IAppEngine Engine { get; set; }

        string ProcessCommand(string command);

        void SeedCommands();
    }
}
