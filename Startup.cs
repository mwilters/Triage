using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Triage.Startup))]
namespace Triage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
