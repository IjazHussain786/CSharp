using HotelBookingSystem.Infrastructure;
using HotelBookingSystem.Models;
using System.Text;
using System.Linq;


namespace HotelBookingSystem.Views.Vеnues
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
            viewResult.AppendFormat("Available rooms for venue {0}:", venue.Name).AppendLine();
            if (!venue.Rooms.Any())
            {
                viewResult.AppendFormat("No rooms are currently available.");
            }
            else
            {
                foreach (var room in venue.Rooms)
                {
                    viewResult.AppendFormat(" *[0] {1} places, ${2:F2} per day", 
                        room.Id, room.PlacesCount, room.PricePerDay).AppendLine();
                    if (!room.AvailableDates.Any())
                    {
                        viewResult.AppendLine("This room is not currently available.");
                    }
                    else
                    {
                        viewResult.AppendLine("Available dates:");
                        foreach (var datePair in room.AvailableDates.OrderBy(datePair => datePair.EndDate))
                        {
                            viewResult.AppendFormat(" - {0:dd.MM.yyyy} - {1:dd.MM.yyyy}", 
                                datePair.EndDate, datePair.StartDate).AppendLine();
                        }
                    }
                }
            }
        }
    }
}
