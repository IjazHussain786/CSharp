using HotelBookingSystem.Infrastructure;
using HotelBookingSystem.Models;
using System.Text;
using System;

namespace HotelBookingSystem.Views.Venues
{
    public class Add : View
    {
        public Add(Venue venue)
            : base(venue)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var venue = this.Model as Venue;
            viewResult.AppendFormat("The venue {0} with ID {1} has been created successfully.{2}", venue.Name, venue.Id, 
                Environment.NewLine);
        }
    }
}