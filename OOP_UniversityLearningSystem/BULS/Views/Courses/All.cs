using System.Text;
using Buls.Infrastructure;
using Buls.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Buls.Views.Courses
{
    public class All : View
    {
        public All(IEnumerable<Course> courses)
            : base(courses)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var courses = this.Model as IEnumerable<Course>;
            
            if (!courses.Any())
            {
                viewResult.AppendLine("No courses.");
            }
            else
            {
                viewResult.AppendLine("All courses:");
                
                foreach (var course in courses)
                {
                    viewResult.AppendFormat("{0} ({1} students){2}", course.Name, course.Students.Count, Environment.NewLine);
                }
            }
        }
    }
}
