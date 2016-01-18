namespace HotelBookingSystem.Identity
{
    using HotelBookingSystem.Interfaces;
    using Models;

    public static class UserExtensions
    {
        public static bool IsInRole(this IUser user, Role role)
        {
            bool isInRole = (user.Role == role);
            return isInRole;
        }
    }
}
