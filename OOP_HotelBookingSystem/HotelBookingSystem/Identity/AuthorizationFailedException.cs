using HotelBookingSystem.Interfaces;
using HotelBookingSystem.Models;
using System;

namespace HotelBookingSystem.Identity
{
    public class AuthorizationFailedException : ArgumentException
    {
        public AuthorizationFailedException(string message, IUser user) : base(message)
        {
            this.User = user;
        }

        public IUser User { get; set; }
    }
}
