using System;
using HotelBookingSystem.Interfaces;
using System.Text;
using HotelBookingSystem.Infrastructure;
using HotelBookingSystem.Models;

namespace HotelBookingSystem.Views.Rooms
{
    public class AddPeriod : View
    {
        public AddPeriod(Room room)
            : base(room)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var room = this.Model as Room;
            viewResult.AppendFormat("The period has been added to room with ID {0}.", room.Id).AppendLine();
        }
    }
}
