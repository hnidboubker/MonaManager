using Microsoft.Owin;
using Mona.Web;
using Owin;

[assembly: OwinStartup(typeof (Startup))]

namespace Mona.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}