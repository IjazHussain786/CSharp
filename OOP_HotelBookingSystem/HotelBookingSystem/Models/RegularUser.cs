using System.Collections.Generic;
using System;
using HotelBookingSystem.Utilities;
using HotelBookingSystem.Interfaces;

namespace HotelBookingSystem.Models
{
    public class RegularUser : User
    {
        public RegularUser(string username, string password, Role role)
            : base(username, password, role)
        {
        }
    }
}
