using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Linkedin.Web.Startup))]
namespace Linkedin.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
