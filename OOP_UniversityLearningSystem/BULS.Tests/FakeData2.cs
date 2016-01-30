using Buls.Interfaces;
using Buls.Models;
using Buls.Data;

namespace BULS.Tests
{
    public class FakeData2 : IBangaloreUniversityData
    {
        public FakeData2()
        {
            this.UsersRepository = new UsersRepository();
            this.CoursesRepository = new FakeCourseRepository2();
        }

        public IUsersRepository UsersRepository { get; private set; }
        public IRepository<Course> CoursesRepository { get; private set; }
    }
}
