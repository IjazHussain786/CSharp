using Buls.Models;
using Buls.Data;

namespace BULS.Tests
{
    public class FakeCourseRepository2 : Repository<Course>
    {
        private readonly Course fakeCourse;

        public FakeCourseRepository2()
            : base()
        {
            this.fakeCourse = new Course("High Quality Code");
            base.Add(fakeCourse);
        }
    }
}
