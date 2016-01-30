using Buls.Models;
using Buls.Data;

namespace BULS.Tests
{
    public class FakeCoursesRepository : Repository<Course>
    {
        private readonly Course fakeCourse;

        public FakeCoursesRepository()
            : base()
        {
            this.fakeCourse = new Course("High Quality Code");
            base.Add(fakeCourse);
        }

        public override Course Get(int id)
        {
            return this.fakeCourse;
        }
    }
}
