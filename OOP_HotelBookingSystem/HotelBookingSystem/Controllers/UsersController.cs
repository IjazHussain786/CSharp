namespace HotelBookingSystem.Controllers
{
    using System;
    using Infrastructure;
    using Models;
    using Utilities;
    using HotelBookingSystem.Interfaces;

    public class UsersController : Controller
    {
        public UsersController(IHotelBookingSystemData data, IUser user)
            : base(data, user)
        {
        }

        public IView Register(string username, string password, string confirmPassword, string role)
        {
            if (password != confirmPassword)
            {
                throw new ArgumentException("The provided passwords do not match.");
            }

            this.EnsureNoLoggedInUser();

            var existingUser = this.Data.RepositoryWithUsers.GetByUsername(username);
            if (existingUser != null)
            {
                throw new ArgumentException(string.Format("A user with username {0} already exists.", username));
            }

            Role userRole = (Role)Enum.Parse(typeof(Role), role, true);
            var user = new User(username, password, userRole);
            this.Data.RepositoryWithUsers.Add(user);
            var view = this.View(user);
            
            return view;
        }

        public IView Login(string username, string password)
        {
            this.EnsureNoLoggedInUser();

            var existingUser = this.Data.RepositoryWithUsers.GetByUsername(username);
            if (existingUser == null)
            {
                throw new ArgumentException(string.Format("A user with username {0} does not exist.", username));
            }

            if (existingUser.PasswordHash != HashUtilities.GetSha256Hash(password))
            {
                throw new ArgumentException("The provided password is wrong.");
            }

            this.CurrentUser = existingUser;
            var view = this.View(existingUser);
            
            return view;
        }

        public IView MyProfile()
        {
            this.Authorize(Role.User, Role.VenueAdmin);
            var view = this.View(CurrentUser);

            return view;
        }

        public IView Logout()
        {
            this.Authorize(Role.User, Role.VenueAdmin);

            var user = this.CurrentUser;
            this.CurrentUser = null;
            var view = this.View(user);

            return view;
        }
    }
}
