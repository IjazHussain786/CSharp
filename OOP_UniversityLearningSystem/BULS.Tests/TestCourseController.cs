using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Buls.Models;
using Buls.Data;
using Buls.Exceptions;
using Buls.Controllers;
using Buls.Interfaces;
using System.Linq;

namespace BULS.Tests
{
    [TestClass]
    public class TestCourseController
    {
        [TestMethod]
        public void TestAddLecture_ValidCourseId_ShouldAddLectureToCourse()
        {
            User lecturer = new User("Pesho", "pasword", Role.Lecturer);
            IBangaloreUniversityData fakeData = new FakeData(); 
            var courseController = new CoursesController(fakeData, lecturer);

            int fakeCourseId = 10;
            IView view = courseController.AddLecture(fakeCourseId, "Refactoring");
            string viewResult = view.Display();

            string expectedAddedLectureName = fakeData.CoursesRepository.GetAll().First().Lectures.GetAll().First().Name;
            Assert.AreEqual(expectedAddedLectureName, "Refactoring",
                "AddLecture() doesn't add lecture when it should.");

            string expectedResult = string.Format("Lecture successfully added to course High Quality Code.");
            Assert.AreEqual(viewResult, expectedResult, "AddLecture() doesn't add lecture when it should.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddLecture_InvalidCourseId_ShouldThrow()
        {
            User lecturer = new User("Pesho", "pasword", Role.Lecturer);
            IBangaloreUniversityData data = new FakeData2();
            var courseController = new CoursesController(data, lecturer);

            int invalidCourseId = 2;
            IView view = courseController.AddLecture(invalidCourseId, "Refactoring");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddLecture_TryAddLectureWhenNoLoggedInUser_ShouldThrow()
        {
            User noUser = null;
            IBangaloreUniversityData fakeData = new FakeData();
            var courseController = new CoursesController(fakeData, noUser);

            int fakeCourseId = 10;
            IView view = courseController.AddLecture(fakeCourseId, "Refactoring");
        }

        [TestMethod]
        [ExpectedException(typeof(AuthorizationFailedException))]
        public void TestAddLecture_TryAddLectureWhenUserIsNotAuthorized_ShouldThrow()
        {
            User lecturer = new User("Pesho", "pasword", Role.Student);
            IBangaloreUniversityData fakeData = new FakeData();
            var courseController = new CoursesController(fakeData, lecturer);

            int fakeCourseId = 10;
            IView view = courseController.AddLecture(fakeCourseId, "Refactoring");
        }
    }
}
