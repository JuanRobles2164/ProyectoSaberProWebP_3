using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProyectoSaberProWeb.Startup))]
namespace ProyectoSaberProWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
