using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProgressTwitter.Web.Startup))]
namespace ProgressTwitter.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
