using Buls.Interfaces;
using Buls.Models;
using Buls.Data;

namespace BULS.Tests
{
    public class FakeData : IBangaloreUniversityData
    {
        public FakeData()
        {
            this.UsersRepository = new UsersRepository();
            this.CoursesRepository = new FakeCoursesRepository();
        }

        public IUsersRepository UsersRepository { get; private set; }
        public IRepository<Course> CoursesRepository { get; private set; }
    }
}
