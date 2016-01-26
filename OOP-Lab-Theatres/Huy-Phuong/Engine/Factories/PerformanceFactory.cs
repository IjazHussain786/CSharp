using System;
using Huy_Phuong.Interfaces;
using Huy_Phuong.Models;

namespace Huy_Phuong.Engine.Factories
{
    public class PerformanceFactory
    {
        public IPerformance CreatePerformance(string theater, string performanceName,
            DateTime startDateTime, TimeSpan performanceDuration, decimal ticketPrice)
        {
            var performance = new Performance(theater, performanceName, startDateTime, performanceDuration, ticketPrice);

            return performance;
        }
    }
}
