using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq;

using Linkedin.Data;
using Linkedin.Models;

namespace Linkedin.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected BaseController(ILinkedinData data)
        {
            this.Data = data;
        }

        protected BaseController(ILinkedinData data, ApplicationUser userProfile)
            : this(data)
        {
            this.UserProfile = userProfile;
        }

        protected ILinkedinData Data { get; private set; }

        protected ApplicationUser UserProfile { get; private set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, 
            object state)
        {
            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                string userName = requestContext.HttpContext.User.Identity.Name;
                var user = this.Data.Users.GetAll().FirstOrDefault(x => x.UserName == userName);
                this.UserProfile = user;
            }

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}