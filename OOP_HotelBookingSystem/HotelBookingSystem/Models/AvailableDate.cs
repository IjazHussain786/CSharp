using System;

namespace HotelBookingSystem.Models 
{
    public class AvailableDate 
    {
        public AvailableDate(DateTime startDate, DateTime endDate) 
        {
            if (endDate < startDate)
            {
                throw new ArgumentException("The date range is invalid.");
            }
            
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        public DateTime StartDate { get; internal set;}
        public DateTime EndDate { get; internal set;}
    }
}