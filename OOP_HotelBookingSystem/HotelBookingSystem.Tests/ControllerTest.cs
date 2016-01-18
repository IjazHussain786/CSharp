using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelBookingSystem.Data;
using HotelBookingSystem.Models;
using System.Collections.Generic;
using HotelBookingSystem.Controllers;

namespace HotelBookingSystem.Tests
{
    [TestClass]
    public class ControllerTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAuthorizeMethodWithEmptyUser()
        {
            string userName = "pesho";
            string password = "pass";
            User user = new User(userName, password, Role.User);
            var database = new HotelBookingSystemData();
            var controler = new UsersController(database, user);

            controler.Login(userName, password);
            controler.Logout();
            controler.Logout();
        }
    }
}
