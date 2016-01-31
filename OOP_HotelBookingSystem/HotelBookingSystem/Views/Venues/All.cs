using HotelBookingSystem.Infrastructure;
using HotelBookingSystem.Models;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System;

namespace HotelBookingSystem.Views.Venues
{
    public class All : View
    {
        public All(IEnumerable<Venue> venues)
            : base(venues)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var venues = this.Model as IEnumerable<Venue>;
            if (!venues.Any())
            {
                viewResult.AppendLine("There are currently no venues to show.");
            }
            else
            {
                foreach (var venue in venues)
                {
                    viewResult.AppendFormat("*[{0}] {1}, located at {2}{3}", venue.Id, venue.Name, venue.Address, 
                        Environment.NewLine);
                    viewResult.AppendFormat("Free rooms: {0}{1}", venue.Rooms.Count, Environment.NewLine);
                }
            }
        }
    }
}
