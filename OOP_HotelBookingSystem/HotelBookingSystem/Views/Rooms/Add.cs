using System;
using HotelBookingSystem.Interfaces;
using System.Text;
using HotelBookingSystem.Infrastructure;
using HotelBookingSystem.Models;

namespace HotelBookingSystem.Views.Rooms
{
    public class Add : View
    {
        public Add(Room room)
            : base(room)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var room = this.Model as Room;
            viewResult.AppendFormat("The room with ID {0} has been created successfully.{1}", room.Id, 
                Environment.NewLine);
        }
    }
}
