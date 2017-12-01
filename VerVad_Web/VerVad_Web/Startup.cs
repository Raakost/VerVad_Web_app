using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VerVad_Web.Startup))]
namespace VerVad_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
