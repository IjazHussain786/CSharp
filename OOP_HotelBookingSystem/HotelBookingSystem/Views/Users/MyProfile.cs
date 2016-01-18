using System;
using HotelBookingSystem.Interfaces;
using System.Text;
using HotelBookingSystem.Infrastructure;
using System.Linq;

namespace HotelBookingSystem.Views.Users
{
    public class MyProfile : View
    {
        public MyProfile(IUser user)
            : base(user)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var user = this.Model as IUser;
            viewResult.AppendLine(user.Username);
            if (!user.Bookings.Any())
            {
                viewResult.AppendLine("You have not made any bookings yet.");
            }
            else
            {
                viewResult.AppendLine("Your bookings:");
                foreach (var booking in user.Bookings)
                {
                    viewResult.AppendFormat
                        ("* {0:dd.MM.yyyy} - {1:dd.MM.yyyy} (${2:F2})",
                        booking.StartBookDate, booking.EndBookDate, booking.TotalPrice).AppendLine();
                }
            }
        }
    }
}
