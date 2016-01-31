using System;
namespace HotelBookingSystem.Controllers
{
    using HotelBookingSystem.Interfaces;
    using Infrastructure;
    using Models;
    using System.Linq;

    public class VenuesController : Controller
    {
        public VenuesController(IHotelBookingSystemData data, IUser user)
            : base(data, user)
        {
        }

        public IView All()
        {
            var venues = this.Data.RepositoryWithVenues.GetAll();
            var view = this.View(venues);
            
            return view;
        }

        public IView Details(int id)
        {
            if (this.HasCurrentUser == false)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }
            
            this.Authorize(Role.User, Role.VenueAdmin);
            
            var venue = this.Data.RepositoryWithVenues.Get(id);
            if (venue == null)
            {
                throw new ArgumentException(string.Format("The venue with ID {0} does not exist.", id));
            }

            var view = this.View(venue);

            return view;
        }

        public IView Rooms(int id)
        {
            if (this.HasCurrentUser == false)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            this.Authorize(Role.User, Role.VenueAdmin);

            var venue = this.Data.RepositoryWithVenues.Get(id);
            if (venue == null)
            {
                throw new ArgumentException(string.Format("The venue with ID {0} does not exist.", id));
            }

            var view = this.View(venue);

            return view;
        }

        public IView Add(string name, string address, string description)
        {
            if (this.HasCurrentUser == false)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            this.Authorize(Role.User, Role.VenueAdmin);
            
            var newVenue = new Venue(name, address, description, CurrentUser);
            this.Data.RepositoryWithVenues.Add(newVenue);
            var view = this.View(newVenue);

            return view;
        }
    }
}