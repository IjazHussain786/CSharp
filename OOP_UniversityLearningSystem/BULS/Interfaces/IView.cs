
namespace Buls.Interfaces
{
    public interface IView
    {
        object Model { get; }
        string Display();
    }
}
