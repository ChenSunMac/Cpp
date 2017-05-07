using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Active_Service_Page.Startup))]
namespace Active_Service_Page
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
