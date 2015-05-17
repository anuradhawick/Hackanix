using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(novacare.Startup))]
namespace novacare
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
