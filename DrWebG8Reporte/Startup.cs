using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DrWebG8Reporte.Startup))]
namespace DrWebG8Reporte
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
