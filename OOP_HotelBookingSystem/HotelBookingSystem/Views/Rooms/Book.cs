using System;
using HotelBookingSystem.Interfaces;
using System.Text;
using HotelBookingSystem.Infrastructure;
using HotelBookingSystem.Models;

namespace HotelBookingSystem.Views.Rooms
{
    public class Book : View
    {
        public Book(Booking booking)
            : base(booking)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var booking = this.Model as Booking;
            viewResult.AppendFormat("Room booked from {0:dd.MM.yyyy} to {1:dd.MM.yyyy} for ${2:F2}.{3}",
                booking.StartBookDate, booking.EndBookDate, booking.TotalPrice, Environment.NewLine);
        }
    }
}
