using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LmycWebSite.Startup))]
namespace LmycWebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
