using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MCGA_WebSite.Startup))]
namespace MCGA_WebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
