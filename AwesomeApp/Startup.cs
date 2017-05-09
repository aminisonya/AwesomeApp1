using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AwesomeApp.Startup))]
namespace AwesomeApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
