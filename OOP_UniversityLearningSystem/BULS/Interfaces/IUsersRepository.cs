using Buls.Models;

namespace Buls.Interfaces
{
    public interface IUsersRepository : IRepository<User>
    {
        User GetByUsername(string username);
    }
}
