using System.Web.Mvc;

using Linkedin.Data;

namespace Linkedin.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ILinkedinData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            if (this.UserProfile != null)
            {
                this.ViewBag.UserName = this.UserProfile.UserName;
            }

            return this.View();
        }

        public ActionResult About()
        {
            this.ViewBag.Message = "Your application description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}