using System;
using System.Linq;
using HotelBookingSystem.Infrastructure;
using HotelBookingSystem.Models;
using HotelBookingSystem.Interfaces;

namespace HotelBookingSystem.Controllers
{
    public class RoomsController : Controller
    {
        public RoomsController(IHotelBookingSystemData data, IUser user)
            : base(data, user)
        {
        }

        /// <summary>
        /// Adds a new bookable room to a system venue (e.g. hotel).
        /// </summary>
        /// <param name="venueId">The id of the venue in the database.</param>
        /// <param name="places">The places count in the the venue (hotel) room.</param>
        /// <param name="pricePerDay">The daily booking rate.</param>
        /// <returns>Views contain the presentation logic in the system. They contain the results which are given to the user.
        /// </returns>
        public IView Add(int venueId, int places, decimal pricePerDay)
        {
            this.Authorize(Role.VenueAdmin);
            var venue = Data.RepositoryWithVenues.Get(venueId);
            if (venue == null)
            {
                throw new ArgumentException(string.Format("The venue with ID {0} does not exist.", venueId));
            }

            var newRoom = new Room(places, pricePerDay);
            venue.Rooms.Add(newRoom);
            Data.RepositoryWithRooms.Add(newRoom);
            return View(newRoom);
        }

        public IView AddPeriod(int roomId, DateTime startDate, DateTime endDate)
        {
            Authorize(Role.VenueAdmin);
            var room = Data.RepositoryWithRooms.Get(roomId);
            if (room == null)
            {
                throw new ArgumentException(string.Format("The room with ID {0} does not exist.", roomId));
            }

            if (endDate < startDate)
            {
                throw new ArgumentException("The date range is invalid.");
            }

            room.AvailableDates.Add(new AvailableDate(startDate, endDate));
            return View(room);
        }

        public IView ViewBookings(int id)
        {
            this.Authorize(Role.VenueAdmin);
            var room = Data.RepositoryWithRooms.Get(id);
            if (room == null)
            {
                throw new ArgumentException(string.Format("The room with ID {0} does not exist.", id));
            }

            return View(room.Bookings);
        }

        public IView Book(int roomId, DateTime startDate, DateTime endDate, string comments)
        {
            this.Authorize(Role.User, Role.VenueAdmin);
            var room = Data.RepositoryWithRooms.Get(roomId);
            if (room == null)
            {
                throw new ArgumentException(string.Format("The room with ID {0} does not exist.", roomId));
            }

            if (endDate < startDate)
            {
                throw new ArgumentException("The date range is invalid.");
            }

            var availablePeriod = room.AvailableDates.FirstOrDefault(d => d.StartDate <= startDate || d.EndDate >= endDate);
            if (availablePeriod == null)
            {
                throw new ArgumentException(
                    string.Format("The room is not available to book in the period {0:dd.MM.yyyy} - {1:dd.MM.yyyy}.",
                    startDate, endDate));
            }

            decimal totalPrice = (endDate - startDate).Days * room.PricePerDay;
            var booking = new Booking(this.CurrentUser, startDate, endDate, totalPrice, comments);
            room.Bookings.Add(booking);
            this.CurrentUser.Bookings.Add(booking);
            
            this.UpdateRoomAvailability(startDate, endDate, room, availablePeriod);
            
            return View(booking);
        }

        private void UpdateRoomAvailability(DateTime startDate, DateTime endDate, Room room, AvailableDate availablePeriod)
        {
            room.AvailableDates.Remove(availablePeriod);
            var periodBeforeBooking = startDate - availablePeriod.StartDate;
            if (periodBeforeBooking > TimeSpan.Zero)
            {
                room.AvailableDates.Add(
                    new AvailableDate(availablePeriod.StartDate, availablePeriod.StartDate.Add(periodBeforeBooking)));
            }

            var periodAfterBooking = availablePeriod.EndDate - endDate;
            if (periodAfterBooking > TimeSpan.Zero)
            {
                room.AvailableDates.Add(
                    new AvailableDate(availablePeriod.EndDate.Subtract(periodAfterBooking), availablePeriod.EndDate));
            }
        }
    }
}
