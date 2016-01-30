using Buls.Interfaces;
using Buls.Data;
using Buls.Models;

namespace Buls.Interfaces
{
    public interface IBangaloreUniversityData
    {
        IUsersRepository UsersRepository { get; }
        IRepository<Course> CoursesRepository { get; }
    }
}
