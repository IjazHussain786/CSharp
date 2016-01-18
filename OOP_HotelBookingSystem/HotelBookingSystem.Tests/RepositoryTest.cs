using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelBookingSystem.Data;
using HotelBookingSystem.Models;
using System.Collections.Generic;

namespace HotelBookingSystem.Tests
{
    [TestClass]
    public class RepositoryTest
    {
        [TestMethod]
        public void TestRepositoryGetMethodWithValidId()
        {
            int roomPlacesCount = 2;
            decimal roomPricePerDay = 20m;
            Room room = new Room(roomPlacesCount, roomPricePerDay);
            Repository<Room> repository = new Repository<Room>();
            repository.Add(room);
            
            int roomIdInRepository = 1;
            var roomFromRepository = repository.Get(roomIdInRepository);

            Assert.AreSame(room, roomFromRepository, "Get() doesn't extract correct object by id.");
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestRepositoryGetMethodWithInvalidId()
        {
            int roomPlacesCount = 2;
            decimal roomPricePerDay = 20m;
            Room room = new Room(roomPlacesCount, roomPricePerDay);
            Repository<Room> repository = new Repository<Room>();
            repository.Add(room);

            int invalidIndex = -1;
            var roomFromRepository = repository.Get(invalidIndex);
        }

    }
}
