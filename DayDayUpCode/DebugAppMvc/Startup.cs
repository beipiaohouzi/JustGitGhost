using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DebugAppMvc.Startup))]
namespace DebugAppMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
