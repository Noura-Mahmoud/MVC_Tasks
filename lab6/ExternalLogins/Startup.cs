using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExternalLogins.Startup))]
namespace ExternalLogins
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
