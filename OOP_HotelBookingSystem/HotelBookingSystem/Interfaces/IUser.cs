using HotelBookingSystem.Models;
using System.Collections.Generic;

namespace HotelBookingSystem.Interfaces
{
    public interface IUser : IDbEntity
    {
        string Username { get; }
        string PasswordHash { get; }
        Role Role { get; }
        ICollection<Booking> Bookings { get; }
    }
}
