using System.Diagnostics;
using Buls.Interfaces;
using System.Reflection;
using Buls.Utilities;
using System.Linq;
using System;
using Buls.Models;
using Buls.Exceptions;

namespace Buls.Controllers
{
    public abstract class Controller
    {
        private const string NamespaceSeparator = ".";
        private const string ControllerSuffix = "Controller";
        private const string ViewsFolder = "Views";
        
        public Controller(IBangaloreUniversityData data, User user)
        {
            this.Data = data;
            this.CurrentUser = user;
        }

        public IBangaloreUniversityData Data { get; private set; }

        public User CurrentUser { get; protected set; }

        public bool HasCurrentUser
        {
            get
            {
                return this.CurrentUser != null;
            }
        }

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

        protected void EnsureAuthorization(params Role[] roles)
        {
            if (!roles.Any(role => CurrentUser.IsInRole(role)))
            {
                throw new AuthorizationFailedException
                    ("The current user is not authorized to perform this operation.", this.CurrentUser);
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
