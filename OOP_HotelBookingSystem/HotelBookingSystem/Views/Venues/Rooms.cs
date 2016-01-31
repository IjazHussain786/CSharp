using HotelBookingSystem.Infrastructure;
using HotelBookingSystem.Models;
using System.Text;
using System.Linq;
using System;


namespace HotelBookingSystem.Views.Venues
{
    public class Rooms : View
    {
        public Rooms(Venue venue)
            : base(venue)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var venue = this.Model as Venue;
            viewResult.AppendFormat("Available rooms for venue {0}:{1}", venue.Name, Environment.NewLine);
            if (!venue.Rooms.Any())
            {
                viewResult.AppendFormat("No rooms are currently available.");
            }
            else
            {
                foreach (var room in venue.Rooms)
                {
                    viewResult.AppendFormat(" *[{0}] {1} places, ${2:F2} per day{3}",
                        room.Id, room.PlacesCount, room.PricePerDay, Environment.NewLine);
                    if (!room.AvailableDates.Any())
                    {
                        viewResult.AppendLine("This room is not currently available.");
                    }
                    else
                    {
                        viewResult.AppendLine("Available dates:");
                        foreach (var datePair in room.AvailableDates.OrderBy(datePair => datePair.EndDate))
                        {
                            viewResult.AppendFormat(" - {0:dd.MM.yyyy} - {1:dd.MM.yyyy}{2}",
                                datePair.StartDate, datePair.EndDate, Environment.NewLine);
                        }
                    }
                }
            }
        }
    }
}
