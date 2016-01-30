using System.Text;
using Buls.Infrastructure;
using Buls.Models;
using System;

namespace Buls.Views.Courses
{
    public class Create : View
    {
        public Create(Course course)
            : base(course)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.Model as Course;
            viewResult.AppendFormat("Course {0} created successfully.{1}", course.Name, Environment.NewLine);
        }
    }
}
