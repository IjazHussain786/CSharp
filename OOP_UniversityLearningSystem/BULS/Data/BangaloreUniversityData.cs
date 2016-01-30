using Buls.Interfaces;
using Buls.Models;

namespace Buls.Data
{
    public class BangaloreUniversityData : IBangaloreUniversityData
    {
        public BangaloreUniversityData()
        {
            this.UsersRepository = new UsersRepository();
            this.CoursesRepository = new Repository<Course>();
        }

        public IUsersRepository UsersRepository { get; private set; }
        public IRepository<Course> CoursesRepository { get; private set; }
    }
}
