using HotelBookingSystem.Identity;
using HotelBookingSystem.Models;
using HotelBookingSystem.Utilities;
using HotelBookingSystem.Views.Shared;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using HotelBookingSystem.Interfaces;

namespace HotelBookingSystem.Infrastructure
{
    /// <summary>
    /// Defines logic for keeping track of a currently logged in user into a system based on 
    /// the the Model-View-Controller architecture.
    /// The controller contains a data layer, consisting of several repositories.
    /// The users actions are being processed through this class.
    /// This is an abstract class, all specific controlles inherit from this class.
    /// </summary>
    public abstract class Controller
    {
        private const string NamespaceSeparator = ".";
        private const string ControllerSuffix = "Controller";
        private const string ViewsFolder = "Views";
        
        /// <summary>
        /// Initializes a new instance of the controller class.
        /// </summary>
        /// <param name="data">The data layer.</param>
        /// <param name="user">The current user of the data layer system.</param>
        public Controller(IHotelBookingSystemData data, IUser user)
        {
            this.Data = data;
            this.CurrentUser = user;
        }

        public IUser CurrentUser { get; set; }

        public bool HasCurrentUser 
        { 
            get 
            { 
                return this.CurrentUser != null; 
            } 
        }

        public IHotelBookingSystemData Data { get; private set; }

        /// <summary>
        /// Creates and returns an object of type view, that will output information about the result
        /// of the action performed by the system user.
        /// </summary>
        /// <param name="model">Models are classes containing information about the real-world object the system works with. 
        /// </param>
        /// <returns>Views contain the presentation logic in the system. They contain the results which are given to the user. </returns>
        protected IView View(object model)
        {
            string fullNamespace = this.GetType().Namespace;
            int firstSeparatorIndex = fullNamespace.IndexOf(NamespaceSeparator);
            string baseNamespace = fullNamespace.Substring(0, firstSeparatorIndex);
            string controllerName = this.GetType().Name.Replace(ControllerSuffix, string.Empty);
            string actionName = new StackTrace().GetFrame(1).GetMethod().Name;
            string fullPath = string.Join(NamespaceSeparator,
                new[] { baseNamespace, ViewsFolder, controllerName, actionName });

            var viewType = Assembly.GetExecutingAssembly().GetType(fullPath);
            
            var view = Activator.CreateInstance(viewType, model) as IView;
            
            return view;
        }

        protected IView NotFound(string message)
        {
            return new Error(message);
        }

        /// <summary>
        /// Checks whether the current system user is authorized to perform a certain action.
        /// </summary>
        /// <param name="roles">The role of the current system user in the system.</param>
        protected void Authorize(params Role[] roles)
        {
            if (!HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            if (!roles.Any(role => CurrentUser.IsInRole(role)))
            {
                throw new AuthorizationFailedException
                    ("The currently logged in user doesn't have sufficient rights to perform this operation.", this.CurrentUser);
            }
        }

        protected void EnsureNoLoggedInUser()
        {
            if (this.HasCurrentUser)
            {
                throw new ArgumentException("There is already a logged in user.");
            }
        }
    }
}
