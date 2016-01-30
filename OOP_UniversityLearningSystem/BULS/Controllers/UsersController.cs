using Buls.Utilities;
using Buls.Interfaces;
using System;
using Buls.Models;

namespace Buls.Controllers
{
    public class UsersController : Controller
    {
        public UsersController(IBangaloreUniversityData data, User user)
            : base(data, user)
        {
        }

        /// <summary>
        /// Registers the user of a MVC architecture application into a repository of users.
        /// Before actual registartion authentications are done to ensure no previously logged in user, 
        /// no user with the same username as the current registrant to be, entered password and repeated password match.
        /// </summary>
        /// <param name="username">User's userame.</param>
        /// <param name="password">User's password.</param>
        /// <param name="confirmPassword">The user password repeated (to avoid spelling mistakes).</param>
        /// <param name="role">The user's role in the application (e.g. student, lecturer).</param>
        /// <returns>An object of type IView, contain the presentation logic in the system. </returns>
        /// <exception cref="ArgumentException">Thrown if the provided passwords do not match. 
        /// Holds a "The provided passwords do not match." error message.</exception>
        /// <exception cref="ArgumentException">Thrown in case of username duplication. 
        /// Holds a "A user with username [username] already exists." error message.</exception>
        public IView Register(string username, string password, string confirmPassword, string role)
        {
            if (password != confirmPassword)
            {
                throw new ArgumentException("The provided passwords do not match.");
            }

            this.EnsureNoLoggedInUser();

            var existingUser = this.Data.UsersRepository.GetByUsername(username);
            if (existingUser != null)
            {
                throw new ArgumentException(string.Format("A user with username {0} already exists.", username));
            }

            Role userRole = (Role)Enum.Parse(typeof(Role), role, true);
            var user = new User(username, password, userRole);
            
            this.Data.UsersRepository.Add(user);
            
            var view = this.View(user);

            return view;
        }

        public IView Login(string username, string password)
        {
            this.EnsureNoLoggedInUser();

            var existingUser = this.Data.UsersRepository.GetByUsername(username);
            if (existingUser == null)
            {
                throw new ArgumentException(string.Format("A user with username {0} does not exist.", username));
            }

            string hashedPassword = HashUtilities.HashPassword(password);
            if (existingUser.Password != hashedPassword)
            {
                throw new ArgumentException("The provided password is wrong.");
            }

            this.CurrentUser = existingUser;

            var view = this.View(existingUser);

            return view;
        }

        public IView Logout()
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            var user = this.CurrentUser;
            this.CurrentUser = null;
            
            var view = this.View(user);

            return view;
        }
    }
}