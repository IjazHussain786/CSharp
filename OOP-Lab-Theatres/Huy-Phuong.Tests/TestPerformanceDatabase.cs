using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Huy_Phuong.Interfaces;
using Huy_Phuong.Data;
using Huy_Phuong.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Globalization;
using Huy_Phuong.Models;

namespace Huy_Phuong.Tests
{
    [TestClass]
    public class TestPerformanceDatabase
    {
        [TestMethod]
        [ExpectedException(typeof(TheaterException))]
        public void TestListTheatres_NoTheatres_ShouldThrowException()
        {
            IPerformanceDatabase performanceDatabase = new PerformanceDatabase();
            performanceDatabase.ListTheatres();
        }

        [TestMethod]
        public void TestListTheatres_ShouldReturnListOfTheatres()
        {
            IPerformanceDatabase performanceDatabase = new PerformanceDatabase();
            performanceDatabase.AddTheatre("Ivan Vazov");
            performanceDatabase.AddTheatre("Theatre 199");

            List<string> testList = new List<string>();
            testList.Add("Ivan Vazov");
            testList.Add("Theatre 199");

            List<string> expectedList = performanceDatabase.ListTheatres().ToList();

            CollectionAssert.AreEqual(testList, expectedList, "ListTheatres() does not retrieve theatres properly.");
        }

        [TestMethod]
        [ExpectedException(typeof(TheatreNotFoundException))]
        public void TestAddPerformance_NonExistingTheatre_ShouldThrow()
        {
            IPerformanceDatabase performanceDatabase = new PerformanceDatabase();

            const string PerformanceStartTimeFormat = "dd.MM.yyyy HH:mm";
            
            string theatreName = "Theatre 199";
            string performanceName = "Duende";
            DateTime startDateTime = DateTime.ParseExact("20.01.2015 20:00", PerformanceStartTimeFormat,
                                    CultureInfo.InvariantCulture);
            TimeSpan duration = TimeSpan.Parse("1:30");
            decimal ticketPrice = 14.50m;
            
            performanceDatabase.AddPerformance(theatreName, performanceName, startDateTime, duration, ticketPrice);
        }

        [TestMethod]
        public void TestAddPerformance_ShouldStorePerformanceToRepository()
        {
            IPerformanceDatabase performanceDatabase = new PerformanceDatabase();
            performanceDatabase.AddTheatre("Theatre 199");

            const string PerformanceStartTimeFormat = "dd.MM.yyyy HH:mm";

            string theatreName1 = "Theatre 199";
            string performanceName1 = "Duende";
            DateTime startDateTime1 = DateTime.ParseExact("20.01.2015 20:00", PerformanceStartTimeFormat,
                                    CultureInfo.InvariantCulture);
            TimeSpan duration1 = TimeSpan.Parse("1:30");
            decimal ticketPrice1 = 14.50m;

            string theatreName2 = "Theatre 199";
            string performanceName2 = "Hamlet";
            DateTime startDateTime2 = DateTime.ParseExact("21.01.2015 20:00", PerformanceStartTimeFormat,
                                    CultureInfo.InvariantCulture);
            TimeSpan duration2 = TimeSpan.Parse("1:30");
            decimal ticketPrice2 = 14.50m;
            
            performanceDatabase.AddPerformance(theatreName1, performanceName1, startDateTime1, duration1, ticketPrice1);
            performanceDatabase.AddPerformance(theatreName2, performanceName2, startDateTime2, duration2, ticketPrice2);

            var performancesList = performanceDatabase.ListPerformances("Theatre 199");

            IPerformance expectedResult1 = new Performance(
                theatreName1, performanceName1, startDateTime1, duration1, ticketPrice1);
            IPerformance expectedResult2 = new Performance(
                theatreName2, performanceName2, startDateTime2, duration2, ticketPrice2);
            var expectedResultsList = new List<IPerformance>();
            expectedResultsList.Add(expectedResult1);
            expectedResultsList.Add(expectedResult2);

            int index = 0;
            foreach (var performance in performancesList)
            {
                Assert.AreEqual(performance.ToString(), expectedResultsList[index].ToString(), 
                    "AddPerformance() does not add performance.");
                index++;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(TheatreNotFoundException))]
        public void TestAddPerformance_OverlappingPerformances_ShouldThrow()
        {
            IPerformanceDatabase performanceDatabase = new PerformanceDatabase();

            const string PerformanceStartTimeFormat = "dd.MM.yyyy HH:mm";

            string theatreName1 = "Theatre 199";
            string performanceName1 = "Duende";
            DateTime startDateTime1 = DateTime.ParseExact("20.01.2015 20:00", PerformanceStartTimeFormat,
                                    CultureInfo.InvariantCulture);
            TimeSpan duration1 = TimeSpan.Parse("1:30");
            decimal ticketPrice1 = 14.50m;
            
            performanceDatabase.AddPerformance(theatreName1, performanceName1, startDateTime1, duration1, ticketPrice1);

            string theatreName2 = "Theatre 199";
            string performanceName2 = "Hamlet";
            DateTime startDateTime2 = DateTime.ParseExact("20.01.2015 21:29", PerformanceStartTimeFormat,
                                    CultureInfo.InvariantCulture);
            TimeSpan duration2 = TimeSpan.Parse("1:30");
            decimal ticketPrice2 = 14.50m;

            performanceDatabase.AddPerformance(theatreName2, performanceName2, startDateTime2, duration2, ticketPrice2);

            string theatreName3 = "Theatre 199";
            string performanceName3 = "Don Juan";
            DateTime startDateTime3 = DateTime.ParseExact("20.01.2015 19:10", PerformanceStartTimeFormat,
                                    CultureInfo.InvariantCulture);
            TimeSpan duration3 = TimeSpan.Parse("1:30");
            decimal ticketPrice3 = 14.50m;

            performanceDatabase.AddPerformance(theatreName3, performanceName3, startDateTime3, duration3, ticketPrice3);

            string theatreName4 = "Theatre 199";
            string performanceName4 = "Don Pedro";
            DateTime startDateTime4 = DateTime.ParseExact("20.01.2015 20:10", PerformanceStartTimeFormat,
                                    CultureInfo.InvariantCulture);
            TimeSpan duration4 = TimeSpan.Parse("1:00");
            decimal ticketPrice4 = 14.50m;

            performanceDatabase.AddPerformance(theatreName4, performanceName4, startDateTime4, duration4, ticketPrice4);
        }

        [TestMethod]
        [ExpectedException(typeof(TheatreNotFoundException))]
        public void TestListPerformances_NoTheatres_ShouldThrowException()
        {
            IPerformanceDatabase performanceDatabase = new PerformanceDatabase();
            performanceDatabase.ListPerformances("Theatre 199");
        }

        [TestMethod]
        [ExpectedException(typeof(TheaterException))]
        public void TestListPerformances_NoPerformances_ShouldThrowException()
        {
            IPerformanceDatabase performanceDatabase = new PerformanceDatabase();
            
            performanceDatabase.AddTheatre("Theatre 199");
            
            performanceDatabase.ListPerformances("Theatre 199");
        }

        //List with existing performances already tested above - method TestAddPerformance_ShouldStorePerformanceToRepository().
    }
}
