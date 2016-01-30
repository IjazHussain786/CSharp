using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Buls.Models;
using Buls.Data;
using Buls.Interfaces;
using Buls.Views.Courses;

namespace BULS.Tests
{
    [TestClass]
    public class TestView
    {
        [TestMethod]
        public void TestDisplay_ShouldBuildValidDisplayResult()
        {
            Course course = new Course("Object Oriented Programming");
            course.Lectures.Add(new Lecture("Refactoring"));
            IView view = new AddLecture(course);
            string viewResult = view.Display();

            string expectedResult = string.Format("Lecture successfully added to course {0}.",
                course.Name);

            Assert.AreEqual(viewResult, expectedResult, "Display() does not build display result properly.");
        }
    }
}
