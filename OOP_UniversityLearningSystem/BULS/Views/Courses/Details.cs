using System.Text;
using Buls.Models;
using Buls.Infrastructure;
using System.Linq;
using System;

namespace Buls.Views.Courses
{
    public class Details : View
    {
        public Details(Course course)
            : base(course)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.Model as Course;

            viewResult.AppendLine(course.Name);
            if (!course.Lectures.GetAll().Any())
            {
                viewResult.AppendLine("No lectures");
            }
            else
            {
                var lectureNames = course.Lectures.GetAll().Select(l => "- " + l.Name);
                viewResult.AppendLine(string.Join(Environment.NewLine, lectureNames));
            }
        }
    }
}
