using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_60322_SPITSYN.Startup))]
namespace _60322_SPITSYN
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
