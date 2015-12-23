using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLR
{
    public class DataBase
    {
        private List<Course> courses;
        public DataBase()
        {
            this.courses = new List<Course>();
        }
        public List<Course> Courses
        {
            get { return this.courses; }
            private set { this.courses = value; }
        }
        public void AddCourse(Course course)
        {
            this.courses.Add(course);
        }
        public void RemoveCourse(string courseName)
        {
            var course = this.courses.FirstOrDefault(c => c.Name == courseName);
            this.courses.Remove(course);
        }
    }
}
