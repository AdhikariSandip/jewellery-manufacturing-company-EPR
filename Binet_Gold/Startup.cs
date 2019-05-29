using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Binet_Gold.Startup))]
namespace Binet_Gold
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
