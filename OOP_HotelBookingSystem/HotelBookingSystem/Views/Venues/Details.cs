using HotelBookingSystem.Infrastructure;
using HotelBookingSystem.Models;
using System.Text;
using System.Linq;
using System;

namespace HotelBookingSystem.Views.Venues
{
    public class Details : View
    {
        public Details(Venue venue)
            : base(venue)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var venue = this.Model as Venue;
            viewResult.AppendLine(venue.Name)
                .AppendFormat("Located at {0}{1}", venue.Address, Environment.NewLine);
            viewResult.AppendFormat("Description: {0}{1}", venue.Description, Environment.NewLine);
            if (!venue.Rooms.Any())
            {
                viewResult.AppendFormat("No rooms are currently available");
            }
            else
            {
                viewResult.AppendLine("Available rooms:");
                foreach (var room in venue.Rooms)
                {
                    viewResult.AppendFormat(" * {0} places (${1:F2} per day){2}", room.PlacesCount, room.PricePerDay, 
                        Environment.NewLine);
                }
            }
        }
    }
}
