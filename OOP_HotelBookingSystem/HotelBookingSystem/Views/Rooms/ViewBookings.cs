﻿using System;
using HotelBookingSystem.Interfaces;
using System.Text;
using HotelBookingSystem.Infrastructure;
using HotelBookingSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace HotelBookingSystem.Views.Rooms
{
    public class ViewBookings : View
    {
        public ViewBookings(IEnumerable<Booking> bookings)
            : base(bookings)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var bookings = this.Model as IEnumerable<Booking>;
            if (!bookings.Any())
            {
                viewResult.AppendLine("There are no bookings for this room.");
            }
            else
            {
                viewResult.AppendLine("Room bookings:");
            }
            foreach (var booking in bookings)
            {
                viewResult.AppendFormat("* {0:dd.MM.yyyy} - {1:dd.MM.yyyy} (${2:F2}){3}", 
                    booking.StartBookDate, booking.EndBookDate, booking.TotalPrice, Environment.NewLine);
            }

            viewResult.AppendFormat("Total booking price: ${0:F2}{1}", bookings.Sum(b => b.TotalPrice),
                    Environment.NewLine);
        }
    }
}
