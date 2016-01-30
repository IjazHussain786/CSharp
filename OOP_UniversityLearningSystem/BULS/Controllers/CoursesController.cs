using Buls.Utilities;
using Buls.Interfaces;
using System;
using System.Linq;
using Buls.Models;

namespace Buls.Controllers
{
    public class CoursesController : Controller
    {
        public CoursesController(IBangaloreUniversityData data, User user)
            : base(data, user)
        {
        }

        public IView All()
        {
            var sortedCourses = this.Data.CoursesRepository.GetAll().
                OrderBy(c => c.Name).ThenByDescending(c => c.Students.Count);
            
            var view = this.View(sortedCourses);
            
            return view;
        }

        public IView Details(int courseId)
        {
            if (this.HasCurrentUser == false)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            this.EnsureAuthorization(Role.Student, Role.Lecturer);

            var courseByID = this.Data.CoursesRepository.Get(courseId);
            
            bool iscourseInCurrentUserCourses = this.CurrentUser.Courses.GetAll().Any(c => c.Name == courseByID.Name);
            if (iscourseInCurrentUserCourses == false)
            {
                throw new ArgumentException("You are not enrolled in this course.");
            }
            
            var view = this.View(courseByID);

            return view;
        }

        public IView Enroll(int courseId)
        {
            if (this.HasCurrentUser == false)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }
            
            this.EnsureAuthorization(Role.Student, Role.Lecturer);

            var course = Data.CoursesRepository.Get(courseId);

            if (this.CurrentUser.Courses.GetAll().Any(c => c.Name == course.Name))
            {
                throw new ArgumentException("You are already enrolled in this course.");
            }

            course.Students.Add(this.CurrentUser);
            this.CurrentUser.Courses.Add(course);

            var view = View(course);

            return view;
        }

        public IView Create(string name)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            this.EnsureAuthorization(Role.Lecturer);

            var course = new Course(name);
            this.Data.CoursesRepository.Add(course);

            var view = View(course);

            return view;
        }
        
        public IView AddLecture(int courseId, string lectureName)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            this.EnsureAuthorization(Role.Lecturer);

            var course = Data.CoursesRepository.Get(courseId);
            var lecture = new Lecture(lectureName);

            course.Lectures.Add(lecture);

            var view = View(course);

            return view;
        }
    }
}
