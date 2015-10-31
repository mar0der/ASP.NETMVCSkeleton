using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Events.App.Startup))]
namespace Events.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
