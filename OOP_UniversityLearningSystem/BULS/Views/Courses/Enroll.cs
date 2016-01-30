using System.Text;
using Buls.Models;
using Buls.Infrastructure;
using System; 

namespace Buls.Views.Courses
{
    public class Enroll : View
    {
        public Enroll(Course course)
            : base(course)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.Model as Course;
            viewResult.AppendFormat("Student successfully enrolled in course {0}.{1}", course.Name, Environment.NewLine);
        }
    }
}
