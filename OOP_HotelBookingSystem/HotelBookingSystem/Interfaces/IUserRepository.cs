using HotelBookingSystem.Models;

namespace HotelBookingSystem.Interfaces
{
    public interface IUserRepository : IRepository<IUser>
    {
        IUser GetByUsername(string username);
    }
}
