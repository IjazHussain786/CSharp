using System;
using System.Collections.Generic;
using Buls.Interfaces;
using Buls.Data;

namespace Buls.Models
{
    public class Course
    {
        private const int CourseNameDefaultLength = 5;
        
        private string courseName;

        public Course(string courseName)
        {
            this.Name = courseName;
            this.Lectures = new Repository<Lecture>();
            this.Students = new Repository<User>();
        }

        public string Name
        {
            get
            {
                return this.courseName;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The course name cannot be empty.");
                }

                if (value.Length < CourseNameDefaultLength)
                {
                    throw new ArgumentException(string.Format("The course name must be at least {0} symbols long.",
                        CourseNameDefaultLength));
                }

                this.courseName = value;
            }
        }

        public IRepository<Lecture> Lectures { get; private set; }

        public IRepository<User> Students { get; private set; }
    }
}
