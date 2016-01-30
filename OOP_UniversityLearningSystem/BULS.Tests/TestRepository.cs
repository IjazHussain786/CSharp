using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Buls.Models;
using Buls.Data;

namespace BULS.Tests
{
    [TestClass]
    public class TestRepository
    {
        [TestMethod]
        public void TestRepositoryGetMethodWithValidId_ShouldReturnCorrectObject()
        {
            Lecture lecture1 = new Lecture("HistoryOfMankind");
            Lecture lecture2 = new Lecture("AncientPhilosophy");
            Repository<Lecture> repository = new Repository<Lecture>();
            repository.Add(lecture1);
            repository.Add(lecture2);

            int lecture2IdInRepository = 2;
            var lectureFromRepository = repository.Get(lecture2IdInRepository);

            Assert.AreSame(lecture2, lectureFromRepository, "Get() doesn't extract correct object by id.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRepositoryGetMethodNegativeId_ShouldThrow()
        {
            Lecture lecture1 = new Lecture("HistoryOfMankind");
            Lecture lecture2 = new Lecture("AncientPhilosophy");
            Repository<Lecture> repository = new Repository<Lecture>();
            repository.Add(lecture1);
            repository.Add(lecture2);

            int invalidIndex = -1;
            var lectureFromRepository = repository.Get(invalidIndex);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRepositoryGetMethodInvalidId_ShouldThrow()
        {
            Lecture lecture1 = new Lecture("HistoryOfMankind");
            Lecture lecture2 = new Lecture("AncientPhilosophy");
            Repository<Lecture> repository = new Repository<Lecture>();
            repository.Add(lecture1);
            repository.Add(lecture2);

            int invalidIndex = -3;
            var lectureFromRepository = repository.Get(invalidIndex);
        }
    }
}
