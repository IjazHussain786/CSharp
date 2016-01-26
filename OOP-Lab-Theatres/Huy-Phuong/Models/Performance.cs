using Huy_Phuong.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huy_Phuong.Models
{
    public class Performance : IPerformance, IComparable, IComparable<Performance>
    {
        public Performance(string theater, string performanceName, 
            DateTime startDateTime, TimeSpan performanceDuration, decimal ticketPrice)
        {
            this.Theater = theater;
            this.Name = performanceName;
            this.StartDateTime = startDateTime;
            this.PerformanceDuration = performanceDuration;
            this.TicketPrice = ticketPrice;
    }

        public string Theater { get; private set; }
        public string Name { get; private set; }
        public DateTime StartDateTime { get; set; }
        public TimeSpan PerformanceDuration { get; private set; }
        public decimal TicketPrice { get; private set; }

        public override string ToString()
        {
            string result = string.Format("({0}, {1}, {2})",
            this.Name, this.Theater, this.StartDateTime.ToString("dd.MM.yyyy HH:mm"));
        
            return result;
        }

        public int CompareTo(Performance other)
        {
            if (this.StartDateTime < other.StartDateTime)
            {
                return -1;
            }
            else if (this.StartDateTime == other.StartDateTime)
            {
                return 0;
            }
            
            return 1;
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            Performance otherPerformance = obj as Performance;
            if (otherPerformance != null)
            {
                return this.StartDateTime.CompareTo(otherPerformance.StartDateTime);
            }
            else
            {
                throw new ArgumentException("Object is not a Performance");
            }
        }
    }
}
