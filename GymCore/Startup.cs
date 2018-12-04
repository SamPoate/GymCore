using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GymCore.Startup))]
namespace GymCore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
