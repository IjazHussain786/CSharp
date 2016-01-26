using Huy_Phuong.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Huy_Phuong.Exceptions;
using Huy_Phuong.Models;
using Huy_Phuong.Engine.Factories;

namespace Huy_Phuong.Data
{
    public class PerformanceDatabase : IPerformanceDatabase
    {
        private readonly SortedDictionary<string, SortedSet<IPerformance>> performances =
                new SortedDictionary<string, SortedSet<IPerformance>>();

        private readonly PerformanceFactory performanceFactory = new PerformanceFactory();

        public void AddTheatre(string theater)
        {
            if (this.performances.ContainsKey(theater))
            {
                throw new DuplicateTheatreException("Error: Duplicate theatre");
            }

            this.performances[theater] = new SortedSet<IPerformance>();
        }

        public IEnumerable<string> ListTheatres()
        {
            var theaters = this.performances.Keys;
            if (theaters.Count == 0)
            {
                throw new TheaterException("No theatres");
            }

            return theaters;
        }

        public void AddPerformance(string theater, string performanceName, DateTime startDateTime, 
            TimeSpan duration, decimal ticketPrice)
        {
            if (!this.performances.ContainsKey(theater))
            {
                throw new TheatreNotFoundException("Error: Theatre does not exist");
            }

            var theaterPerformances = this.performances[theater];
            var performanceEnd = startDateTime + duration;
            if (IsOverlapping(theaterPerformances, startDateTime, performanceEnd))
            {
                throw new TimeDurationOverlapException("Error: Time/duration overlap");
            }

            var performance = this.performanceFactory.CreatePerformance(
                theater, performanceName, startDateTime, duration, ticketPrice);
            theaterPerformances.Add(performance);
        }

        public IEnumerable<IPerformance> ListAllPerformances()
        {
            var theatres = this.performances.Keys;
            if (theatres.Count == 0)
            {
                throw new TheaterException("No performances");
            }

            var result = new List<IPerformance>();
            foreach (var theater in theatres)
            {
                var performances = this.performances[theater];
                result.AddRange(performances);
            }

            if (result.Count == 0)
            {
                throw new TheaterException("No performances");
            }

            return result;
        }

        public IEnumerable<IPerformance> ListPerformances(string theatreName)
        {
            if (!this.performances.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException("Error: Theatre does not exist");
            }
            
            var result = this.performances[theatreName];
            if (result.Count == 0)
            {
                throw new TheaterException("No performances");
            }

            return result;
        }

        private bool IsOverlapping(IEnumerable<IPerformance> performances, DateTime startDateTime, DateTime performanceEnd)
        {
            foreach (var performance in performances)
            {
                var currentPerformanceStart = performance.StartDateTime;
                var currentPerformanceEnd = performance.StartDateTime + performance.PerformanceDuration;
                bool isOverlapping = IsOverlapping(currentPerformanceStart, currentPerformanceEnd, startDateTime, performanceEnd);

                if (isOverlapping)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsOverlapping(DateTime start1, DateTime end1, DateTime start2, DateTime end2)
        {
            var isOpervapping =
                (start1 <= start2 && start2 <= end1) ||
                (start1 <= end2 && end2 <= end1) ||
                (start2 <= start1 && start1 <= end2) ||
                (start2 <= end1 && end1 <= end2);
            
            return isOpervapping;
        }
    }
}
