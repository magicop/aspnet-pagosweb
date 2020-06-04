using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebPagos.Startup))]
namespace WebPagos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
